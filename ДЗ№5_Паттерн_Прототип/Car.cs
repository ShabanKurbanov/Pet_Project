using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_5_Паттерни_Прототип
{
	public class Car : Vehicle, IMyCloneable<Car>, ICloneable
	{
		public int Doors { get; }
		public string? BodyType { get; }

		public Car(string brand, string model, string vin, int doors, string bodyType) : base(brand, model, vin)
		{
			Doors = doors;
			BodyType = bodyType;
		}

		//Конструктор копирования
		protected Car(Car other) : base(other)
		{
			Doors = other.Doors;
			BodyType = other.BodyType;
		}

		//Реализация дженери-прототипа
		public virtual new Car MyClone()
		{
			return new Car(this);
		}

		//Переопределяем базовый MyClone, чтобы при работе через Vehicle возврашался правильный тип
		Car IMyCloneable<Car>.MyClone()
		{
			return MyClone();
		}

		//Реализация стандарта IConeable через наш MyClone
		public override object Clone()
		{
			return MyClone();
		}

		public override string ToString()
		{
			return base.ToString() + $", Doors = {Doors}, Body = {BodyType}";
		}
	}
}
