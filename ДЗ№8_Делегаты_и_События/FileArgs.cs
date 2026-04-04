using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_8_Делегаты_и_События
{
	//Класс аргументов события при нахождении файла
	//Наследуется от EventArgs согласно .NET соглашениям
	public class FileArgs : EventArgs
	{
		//Имя найденного файла
		public string? FileName { get; set; }

		//Флаг отмены дальнейшего поиска
		//Если установить в true - поиск остановистя 
		public bool Cancel { get; set; }
	}
}
