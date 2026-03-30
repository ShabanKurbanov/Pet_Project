using System;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;

namespace ДЗ_7_Рефлексия_и_ее_применение
{
	//Быстрый CSV сериализатор и использованием:
	//1. Кэширования Reflection
	//2. Expression Trees (для ускорения доступа к свойствам)
	public static class FastCsvSerializer<T> where T : new()
	{
		//Массив делегатов для чтения значений свойств
		private static readonly Func<T, object>[]? Getters;

		//Массив делегатов для записи значений свойств
		private static readonly Action<T, object>[]? Setters;

		//Статический конструктор выполняется 1 раз на тип Т
		//Здесь кэшируем все свойства и создаем бытрые делегаты
		static FastCsvSerializer()
		{
			//Получаем все публичные свойства класса
			var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

			//Создаем массив быстрых геттеров (чтение значений)
			Getters = props.Select(CreateGetter).ToArray();

			//Создаем массив быстрых сеттеров (запись значений)
			Setters = props.Select(CreateSetter).ToArray();
		}

		//Создание делегата для чтения свойств (getter)
		//Используем Expression  вместо Reflection для ускорения
		private static Func<T, object> CreateGetter(PropertyInfo prop)
		{
			//Параметр: объект класс (х)
			var param = Expression.Parameter(typeof(T), "x");

			//Доступ к свойству: x.Property
			var property = Expression.Property(param, prop);

			//Приведение к object (так как возвращаем object)
			var convert = Expression.Convert(property, typeof(object));

			//Компиляция в делегат: x => (object)x.Property
			return Expression.Lambda<Func<T, object>>(convert, param).Compile();
		}

		//Создание делегата для записи свойства (setter)
		private static Action<T, object> CreateSetter(PropertyInfo prop)
		{
			//Параметры: объект и значение 
			var obj = Expression.Parameter(typeof(T), "obj");
			var value = Expression.Parameter(typeof(object), "val");

			//Приведение значения к типу свойства
			var convert = Expression.Convert(value, prop.PropertyType);

			//Допступ к свойству
			var property = Expression.Property(obj, prop);

			//Присваивание: obj.Property = (Type)Value
			var assing = Expression.Assign(property, convert);

			//Компиляция в делегат
			return Expression.Lambda<Action<T, object>>(assing, obj, value).Compile();
		}

		//Сериализация объекта в CSV строку
		public static string Setialize(T obj)
		{
			var sb = new StringBuilder();

			//Проходим по всем свойствам
			for (int i = 0; i < Getters.Length; i++)
			{
				if(i > 0)
					sb.Append(","); //Разделить CSV

				//Получаем значение через делегат (быстро)
				var valut = Getters[i](obj);

				sb.Append(valut);
			}

			return sb.ToString();
		}

		//Десериализация CSV строки в объект
		public static T Deserialize(string csv)
		{
			var values = csv.Split(',');

			var obj = new T();

			//Заполняем свойства объект
			for(int i = 0; i < values.Length; i++)
			{
				//Преобразуем строку в нужный тип (здесь int для примера)
				var val = Convert.ChangeType(values[i], typeof(int));

				//Устанавливаем значение через делегат
				Setters![i](obj, val);
			}

			return obj;
		}
	}

}
