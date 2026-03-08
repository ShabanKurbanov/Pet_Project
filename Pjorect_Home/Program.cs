using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

class Program
{
	static async Task Main()
	{
		Console.WriteLine("=== Домашнее задание: Параллельное считывание файлов ===\n");

		// Задание 1: Параллельное чтение 3 файлов
		await Task1_ThreeFiles();

		Console.WriteLine("\n" + new string('=', 60) + "\n");

		// Задание 2+3: Функция для папки с замером времени
		await Task2_FolderProcessing();
	}

	// Задание 1: Параллельное чтение трёх конкретных файлов (7 баллов)
	static async Task Task1_ThreeFiles()
	{
		Console.WriteLine("Задание 1: Параллельное чтение 3 файлов");

		// указать имена своих файлов и пути к ним
		var filePaths = new[]
		{
			@"E:\file1.txt",
			@"E:\file2.txt",
			@"E:\file3.txt"
		};

		var sw = Stopwatch.StartNew();

		Task<int>[] tasks = filePaths
			.Select(path => Task.Run(() => CountSpacesInFile(path)))
			.ToArray();

		int[] results = await Task.WhenAll(tasks);
		sw.Stop();

		Console.WriteLine("Результаты:");
		int totalSpaces = 0;
		for (int i = 0; i < filePaths.Length; i++)
		{
			Console.WriteLine($"  {filePaths[i]}: {results[i]} пробелов");
			totalSpaces += results[i];
		}
		Console.WriteLine($"  Общее количество пробелов: {totalSpaces}");
		Console.WriteLine($"  Время выполнения: {sw.ElapsedMilliseconds} мс");
	}

	// Задание 2: Функция для чтения всех файлов из папки (+2 балла)
	static async Task Task2_FolderProcessing()
	{
		Console.WriteLine("Задание 2: Чтение всех файлов из папки");

		// Здесь необходимо указать свой путь
		string folderPath = @"E:\MyFolder";

		var sw = Stopwatch.StartNew();
		int totalSpaces = await CountSpacesInFolderAsync(folderPath);
		sw.Stop();

		Console.WriteLine($"Всего пробелов во всех файлах: {totalSpaces}");
		Console.WriteLine($"Время выполнения: {sw.ElapsedMilliseconds} мс");
	}

	// Универсальная функция подсчёта пробелов в файле
	static int CountSpacesInFile(string path)
	{
		if (!File.Exists(path))
			return 0; // Защита от отсутствующих файлов

		string text = File.ReadAllText(path);
		return text.Count(c => c == ' ');
	}

	// Функция для задания 2 - принимает путь к папке и параллельно читает все файлы
	static async Task<int> CountSpacesInFolderAsync(string folderPath)
	{
		if (!Directory.Exists(folderPath))
		{
			Console.WriteLine($"Папка {folderPath} не существует!");
			return 0;
		}

		string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
		Console.WriteLine($"Найдено файлов: {files.Length}");

		if (files.Length == 0)
			return 0;

		Task<int>[] tasks = files
			.Select(path => Task.Run(() => CountSpacesInFile(path)))
			.ToArray();

		int[] results = await Task.WhenAll(tasks);
		return results.Sum();
	}
}
