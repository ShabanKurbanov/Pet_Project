using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ДЗ_6_Демонстрация_SOLID_Принципов.Config;
using ДЗ_6_Демонстрация_SOLID_Принципов.Intarfaces;

namespace ДЗ_6_Демонстрация_SOLID_Принципов.Game
{
	//Класс содержит основную логику игры
	//Принцип SPR - отвечает только за игровую логику
	public class GameLogic
	{
		//Загаданное число
		private readonly int secretNumber;

		//Количество отсавшихся попыток
		private int attemptsLeft;

		//Конструктор игры
		public GameLogic(GameSettings settings, INumberGenerator generator)
		{
			//Генерируем случайное число в заданном диапазоне
			secretNumber = generator.Generate(settings.MinNumber, settings.MaxNumber);

			//Устанавливаем количество попыток
			attemptsLeft = settings.MaxAttempts;
		}

		//Метод проверки введенного числа
		public GuessResult Guess(int number)
		{
			//Уменьшаем количество оставшихся попыток
			attemptsLeft--;

			//Если число меньше загаданного
			if(number < secretNumber)
				return GuessResult.TooSmall;

			//Если число больше загаданного
			if(number > secretNumber)
				return GuessResult.TooBig;

			//Если число угадано
			return GuessResult.Correct;
		}

		//Свойство для получения оставшихся попыток
		public int AttmptLeft => attemptsLeft;
	}
}
