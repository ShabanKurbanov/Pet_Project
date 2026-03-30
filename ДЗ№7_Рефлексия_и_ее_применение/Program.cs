using System;
using System.Diagnostics;
using System.Text.Json;
using ДЗ_7_Рефлексия_и_ее_применение;

namespace Program
{
	class Program
	{
		static void Main()
		{
			int iterations = 10000;

			//Получаем тестовый объект
			var obj = F.Get();

			FastCsvSerializer<F>.Setialize(obj);

			var sw = new Stopwatch();

			//--------CSV Serialization--------
			sw.Start();

			string csv = "";

			for (int i = 0; i < iterations; i++)
			{
				csv = FastCsvSerializer<F>.Setialize(obj);
			}

			sw.Stop();
			Console.WriteLine($"CSV Serialize: {sw.ElapsedMilliseconds} ms");

			//-------CSV Deserializtion-------
			sw.Restart();

			for(int i = 0; i < iterations; i++)
			{
				FastCsvSerializer<F>.Deserialize(csv);
			}

			sw.Stop();
			Console.WriteLine($"CSV Desialize: {sw.ElapsedMilliseconds} ms");


			//-------JSON Serializtion------------
			sw.Restart();

			string json = "";

			for(int i = 0; i < iterations; i++)
			{
				json = JsonSerializer.Serialize(obj);
			}

			sw.Stop();
			Console.WriteLine($"JSON Serialize: {sw.ElapsedMilliseconds} ms");

			//-------JSON Desirialize----------
			sw.Restart();

			for(int i = 0; i < iterations; i++)
			{
				JsonSerializer.Deserialize<F>(json);
			}

			sw.Stop();
			Console.WriteLine($"JSON Desialize: {sw.ElapsedMilliseconds} ms");


			//-----Console OUTPUT------
			sw.Restart();

			Console.WriteLine(csv);

			sw.Stop();
			Console.WriteLine($"Console write: {sw.ElapsedMilliseconds} ms");

		}
	}
}