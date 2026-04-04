using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_8_Делегаты_и_События
{
	//Статический класс для хранения методов расширения
	public static class EnumerableExtensions
	{
		//Возвращает максимальный элемент коллекции на основе переданного критерия
		public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> converterToNumber) where T: class
		{
			//Проверка на null
			if(collection == null)
				throw new ArgumentNullException(nameof(collection));

			if(converterToNumber == null)
				throw new ArgumentNullException(nameof(converterToNumber));

			//Переменная для хранения максимального элемента
			T maxElement = null;

			//Минимальное возможное значение float
			float maxValue = float.MinValue;

			//Перебор всех элементов коллекции
			foreach(var item in collection)
			{
				//Получаем числовое значение через делегат
				float value = converterToNumber(item);

				//Если это первый элемент или найден элемент больше текущего максимума
				if(maxElement == null || value > maxValue)
				{
					maxValue = value;
					maxElement = item;
				}
			}

			//Возвращаем найденный максимум
			return maxElement;
		}
	}
}
