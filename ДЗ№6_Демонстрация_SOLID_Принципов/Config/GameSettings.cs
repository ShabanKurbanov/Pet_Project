
namespace ДЗ_6_Демонстрация_SOLID_Принципов.Config
{
	//Класс содержит настройки игры (диапазон чисел и количество попыток)
	//Принцип SRP - класс отвечает только за хранение конфигурации
	public class GameSettings
	{
		//Минимальное число диапазона
		public int MinNumber { get; }

		//Максимальное число диапазона
		public int MaxNumber { get; }

		//Максимальное количество попыток
		public int MaxAttempts { get; }

		//Конструктор для установки настроек
		public GameSettings(int minNumber, int maxNumber, int maxAttents)
		{
			MinNumber = minNumber;
			MaxNumber = maxNumber;
			MaxAttempts = maxAttents;
		}
	}
}
