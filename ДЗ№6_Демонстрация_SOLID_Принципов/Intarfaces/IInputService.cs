
namespace ДЗ_6_Демонстрация_SOLID_Принципов.Intarfaces
{
	//Интерфейс сервиса ввода
	//Принцип ISP - отдельный интерфейс только для ввода
	public interface IInputService
	{
		//Метод чтения числа
		int ReadNumber();
	}
}
