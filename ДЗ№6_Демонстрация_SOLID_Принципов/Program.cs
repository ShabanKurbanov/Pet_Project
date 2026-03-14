using ДЗ_6_Демонстрация_SOLID_Принципов;
using ДЗ_6_Демонстрация_SOLID_Принципов.Config;
using ДЗ_6_Демонстрация_SOLID_Принципов.Game;
using ДЗ_6_Демонстрация_SOLID_Принципов.Intarfaces;
using ДЗ_6_Демонстрация_SOLID_Принципов.Services;

namespace Program
{
	class Program
	{
		public static void Main()
		{
			//Создаем настройки игры
			var settings = new GameSettings(1, 100, 10);

			//Создаем генератор случайных чисел
			INumberGenerator generator = new RandomNumberGenerator();

			//Создаем сервис ввода
			IInputService input = new ConsoleInputService();

			//Создаем сервис вывода
			IOutputService output = new ConsoleOutputService();

			//Создаем объект логики игры
			var game = new GameLogic(settings, generator);

			//Создаем контроеллер игры
			var controller = new GameController(input, output, game);

			//Запускаем игру
			controller.Start();
		}
	}
}