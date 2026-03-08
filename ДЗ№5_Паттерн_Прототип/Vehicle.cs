using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_5_Паттерни_Прототип
{
	public abstract class Vehicle : IMyCloneable<Vehicle>, ICloneable
	{
		public string? Brand { get; set; }
		public string? Model { get; set; }
		public string? Vin { get; }

		protected Vehicle(string brand, string model, string vin)
		{
			Brand = brand;
			Model = model;
			Vin = vin;
		}

		//Конструктор копирования
		protected Vehicle(Vehicle other)
		{
			Brand = other.Brand;
			Model = other.Model;
			Vin = other.Vin;
		}


		public virtual Vehicle MyClone()
		{
			return new VehicleImpl(this);
		}

		public virtual object Clone()
		{
			return MyClone();
		}
		
		//Вспомогательный приватный класс, чтобы асбстрактный Vehicle тоже можно было клонировать
		private sealed class VehicleImpl : Vehicle
		{
			public VehicleImpl(Vehicle other) : base(other) { }
		}

		public override string ToString()
		{
			return $"{GetType().Name}: {Brand} {Model}, VIN = {Vin}";
		}
	}
}
