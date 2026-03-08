using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_5_Паттерни_Прототип
{
	public class ElectricCar : Car, IMyCloneable<ElectricCar>, ICloneable
	{
		public int BatteryCapacityKwh { get; }
		public int RangeKm { get; }

		public ElectricCar(string brand, string model, string vin, int doors, string bodyType, int batteryCapacityKwn, int rangeKm)
			: base(brand, model, vin, doors, bodyType)
		{
			BatteryCapacityKwh = batteryCapacityKwn;
			RangeKm = rangeKm;
		}

		//Конструктор копирования
		protected ElectricCar(ElectricCar other) : base(other)
		{
			BatteryCapacityKwh = other.BatteryCapacityKwh;
			RangeKm = other.RangeKm;
		}

		public new ElectricCar MyClone()
		{
			return new ElectricCar(this);
		}

		ElectricCar IMyCloneable<ElectricCar>.MyClone()
		{
			return MyClone();
		}

		public override object Clone()
		{
			return MyClone();
		}

		public override string ToString()
		{
			return base.ToString() + $", Battary = {BatteryCapacityKwh}kWh, Range = {RangeKm}";
		}
	}
}
