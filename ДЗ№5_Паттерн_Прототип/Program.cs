using System;
using ДЗ_5_Паттерни_Прототип;

namespace Prgram
{
	public static class Program
	{
		public static void Main()
		{
			Car car = new Car("Toyota", "Camry", "VIN123", 4, "Sedan");
			ElectricCar tesla = new ElectricCar("Tesla", "Model 3", " VIN999", 4, "Sedan", 75, 450);
			Truck truck = new Truck("Volvo", "FH16", "VIN777", 20.5, true);

			Car carClone = car.MyClone();
			ElectricCar teslaClone = (ElectricCar)tesla.Clone(); //Через IClonable
			Truck truckClone = truck.MyClone();

			Console.WriteLine("Оригинальная:");
			Console.WriteLine(car);
			Console.WriteLine(tesla);
			Console.WriteLine(truck);

			Console.WriteLine(new string('-',50));

			Console.WriteLine("Копия:");
			Console.WriteLine(carClone);
			Console.WriteLine(teslaClone);
			Console.WriteLine(truckClone);

			Console.WriteLine(new string('-', 50));

			//Проверки, что это разные объекты
			Console.WriteLine($"car == carClone || {ReferenceEquals(car, carClone)}");
			Console.WriteLine($"tesla == teslaClone || {ReferenceEquals(tesla, teslaClone)}");
			Console.WriteLine($"truck == truckClone || {ReferenceEquals(truck, truckClone)}");

		}
	}
}