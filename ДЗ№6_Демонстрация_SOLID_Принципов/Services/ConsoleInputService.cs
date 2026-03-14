using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ДЗ_6_Демонстрация_SOLID_Принципов.Intarfaces;

namespace ДЗ_6_Демонстрация_SOLID_Принципов.Services
{
	//Класс отвечает за ввод данных из консоли
	//Реализует интерфейс IInputService
	public class ConsoleInputService : IInputService
	{
		public int ReadNumber()
		{
			// Считывает строку из консоли
			string? input = Console.ReadLine();

			//Преобразует сроку в число
			return int.Parse(input!);
		}
	}
}
