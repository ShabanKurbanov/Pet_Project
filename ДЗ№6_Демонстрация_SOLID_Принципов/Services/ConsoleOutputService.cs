using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ДЗ_6_Демонстрация_SOLID_Принципов.Intarfaces;

namespace ДЗ_6_Демонстрация_SOLID_Принципов.Services
{
	//Класс отвечает за вывод сообщений в консоль
	//Реализует интерфейс IOutputService
	public class ConsoleOutputService : IOutputService
	{
		public void ConsoleTextColor(ConsoleColor color)
		{
			Console.ForegroundColor = color;
		}

		public void Write(string message)
		{
			//Вывод сообщения пользоватею
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
