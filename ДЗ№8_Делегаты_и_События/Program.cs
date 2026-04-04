using System;
using System.Collections.Generic;
using ДЗ_8_Делегаты_и_События;

namespace Program
{
	class Program
	{
		static void Main()
		{
			//-----Пример работы GetMax------

			//Создаем список строк
			var files = new List<string>()
			{
				"short.txt",
				"very_long_filename.txt",
				"mid.txt"
			};

			//Находим строку с максимальной длиной
			//f => f.Length - это делегат Func<string, float>
			var maxFile = files.GetMax(f => f.Length);

			Console.WriteLine($"Самая длинная строка: {maxFile}");

			//-----Пример работы FileSearcher------

			var searcher = new FileSearcher();

			//Подписка на событие 
			searcher.FileFound += (sender, e) =>
			{
				Console.WriteLine($"Найден файл: {e.FileName}");

				//Пример остановки поиска
				if (e.FileName!.Contains("stop"))
				{
					Console.WriteLine("Обнаружен файл с 'stop'. Останавливаем поиск.");
					e.Cancel = true;
				}
			};

			//Запуск поиска (указать свой папку)
			searcher.Search(@"E:\TestFolder");
		}
	}
}