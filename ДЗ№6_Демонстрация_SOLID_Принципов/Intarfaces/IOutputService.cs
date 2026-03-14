
using System.Drawing;

namespace ДЗ_6_Демонстрация_SOLID_Принципов.Intarfaces
{
	//Интерфейс сервиса вывода
	//Принцип ISP - отдельный интерфейс только для вывода
	public interface IOutputService
	{
		//Цвет текса консоли
		void ConsoleTextColor(ConsoleColor color);

		//Метод вывода сообщения
		void Write(string message);
	}
}
