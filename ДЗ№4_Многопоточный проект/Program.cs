using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArraySumBenchmark
{
	class Program
	{
		private static long[]? array;
		private static long sumResult = 0;
		private static readonly object lockObject = new object();

		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			int[] sizes = { 100000, 1000000, 10000000 };

			Console.WriteLine("=== Замеры времени вычисления суммы массива ===");
			Console.WriteLine();

			foreach (int size in sizes)
			{
				Console.WriteLine($"Размер массива: {size:N0}");
				Console.WriteLine(new string('-', 60));

				// Заполняем массив случайными числами (int.MaxValue для максимальной нагрузки)
				array = new long[size];
				Random rand = new Random(42); // фиксированный сид для воспроизводимости
				for (int i = 0; i < size; i++)
				{
					array[i] = rand.Next(1, int.MaxValue);
				}

				// Последовательное вычисление
				var sequentialTime = MeasureSequential();

				// Параллельное с Thread
				var threadTime = MeasureThreadParallel();

				// Параллельное с LINQ
				var linqTime = MeasureLinqParallel();

				Console.WriteLine($"Последовательное: {sequentialTime} мс");
				Console.WriteLine($"Thread:          {threadTime} мс");
				Console.WriteLine($"LINQ Parallel:   {linqTime} мс");
				Console.WriteLine();
			}
		}

		// 1. Последовательное вычисление
		static double MeasureSequential()
		{
			var sw = Stopwatch.StartNew();
			sumResult = 0;
			for (int i = 0; i < array!.Length; i++)
			{
				sumResult += array[i];
			}
			sw.Stop();
			return sw.ElapsedMilliseconds;
		}

		// 2. Параллельное с Thread (разделяем на 4 потока)
		static double MeasureThreadParallel()
		{
			int threadCount = Environment.ProcessorCount;
			int chunkSize = array!.Length / threadCount;
			List<Thread> threads = new List<Thread>();
			long[] partialSums = new long[threadCount];

			var sw = Stopwatch.StartNew();

			// Создаем и запускаем потоки
			for (int i = 0; i < threadCount; i++)
			{
				int start = i * chunkSize;
				int end = (i == threadCount - 1) ? array.Length : start + chunkSize;
				int threadIndex = i;

				Thread thread = new Thread(() =>
				{
					long localSum = 0;
					for (int j = start; j < end; j++)
					{
						localSum += array[j];
					}
					partialSums[threadIndex] = localSum;
				});

				threads.Add(thread);
				thread.Start();
			}

			// Ждем завершения всех потоков
			foreach (var thread in threads)
			{
				thread.Join();
			}

			// Суммируем результаты
			sumResult = 0;
			foreach (var partial in partialSums)
			{
				sumResult += partial;
			}

			sw.Stop();
			return sw.ElapsedMilliseconds;
		}

		// 3. Параллельное с LINQ (ParallelEnumerable)
		static double MeasureLinqParallel()
		{
			var sw = Stopwatch.StartNew();
			sumResult = array!.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount).Sum();
			sw.Stop();
			return sw.ElapsedMilliseconds;
		}
	}
}
