using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ДЗ_6_Демонстрация_SOLID_Принципов.Game;
using ДЗ_6_Демонстрация_SOLID_Принципов.Intarfaces;

namespace ДЗ_6_Демонстрация_SOLID_Принципов
{
	//Класс управляет процессом игры
	//Отвечает за взаимодействие между пользователем и логикой игры
	public class GameController
	{
		//Сервис ввода
		private readonly IInputService? _input;

		//Сервис вывода
		private readonly IOutputService? _output;

		//Логика игры
		private readonly GameLogic? _game;

		//Конструктор
		//Здесь используется Dependency Injection
		public GameController(IInputService input, IOutputService output, GameLogic game)
		{
			this._input = input;
			this._output = output;
			this._game = game;
		}

		//Метод запуска игры
		public void Start()
		{
			//Цикл игры продолжается пока есть попытка
			while (_game!.AttmptLeft > 0)
			{
				//Просим пользователся ввести число
				_output!.Write("Введите число:");

				//Читаем число
				int guess = _input!.ReadNumber(); 

				//Проверяем результат попытки
				var result = _game.Guess(guess);

				//Обрабатываем результат
				switch (result)
				{
					case GuessResult.TooSmall:
						_output.Write("Загаданное число больше");
						break;
					case GuessResult.TooBig:
						_output.Write("Загаданное число меньше");
						break;
					case GuessResult.Correct:
						_output.ConsoleTextColor(ConsoleColor.Green);
						_output.Write("Вы угадали");
						return;
				}

				//Показываем сколько попыток осталось
				_output.Write($"Осталось попыток: {_game.AttmptLeft}");
			}

			//Сообщение если попытки закончились 
			_output!.ConsoleTextColor(ConsoleColor.Red);
			_output!.Write("Попытки закончились. Вы проиграли");
		}
	}
}
