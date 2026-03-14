
namespace ДЗ_6_Демонстрация_SOLID_Принципов.Intarfaces
{
	//Интерфейс генерации числа
	//Принцип DIP - зависимость от абстракции, а не от конкретной реализации
	public interface INumberGenerator
	{
		//Метод генерации случайного числа
		int Generate(int min, int max);
	}
}
