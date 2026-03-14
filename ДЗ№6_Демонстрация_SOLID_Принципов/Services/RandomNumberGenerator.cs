using ДЗ_6_Демонстрация_SOLID_Принципов.Intarfaces;

namespace ДЗ_6_Демонстрация_SOLID_Принципов.Services
{
	//Класс отвечает за генерацию случайного числа
	//Реализует интерфейс INumberGenerator
	public class RandomNumberGenerator : INumberGenerator
	{
		//Объект генератора случайных чисел
		private readonly Random random = new Random();

		//Метод генерации числа в заданном диапазоне
		public int Generate(int min, int max)
		{
			//random.Next генерирует число от min до max + 1
			return random.Next(min, max + 1);
		}
	}
}
