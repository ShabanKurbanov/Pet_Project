using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_8_Делегаты_и_События
{
	//Класс для поиска файлов в каталоге
	public class FileSearcher
	{
		//Событие, возникающее при нахождении файла
		//Используется стандартный делегат EventHandler<T>
		public event EventHandler<FileArgs>? FileFound;

		//Метод запуска поиска файлов
		public void Search(string path)
		{
			//Проверка существования директории
			if (!Directory.Exists(path))
				throw new DirectoryNotFoundException();

			//Перебор всех файлов (включая вложенные папки)
			foreach(var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
			{
				//Создание аргументов события
				var args = new FileArgs { FileName = file };

				//Вызов события
				OnFileFound(args);

				//Если обработчик установил Cancel = true - прекращаем поиск
				if (args.Cancel)
				{
					Console.WriteLine("Поиск отменен.");
					break;
				}
			}
		}

		//Метод безопасного вызова события
		protected virtual void OnFileFound(FileArgs args)
		{
			//Проверка на наличие подписчиков и вызов события
			FileFound?.Invoke(this, args);
		}
	}
}
