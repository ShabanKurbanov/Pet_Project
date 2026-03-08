using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_5_Паттерни_Прототип
{
	public class Truck : Vehicle, IMyCloneable<Truck>, ICloneable
	{
		public double CapacityTons { get; }
		public bool HasTrailer { get; }

		public Truck(string brand, string model, string vin, double capacityTons, bool hasTrailer) : base(brand, model, vin)
		{
			CapacityTons = capacityTons;
			HasTrailer = hasTrailer;
		}

		//Конструктор копирования
		protected Truck(Truck other) : base(other)
		{
			CapacityTons = other.CapacityTons;
			HasTrailer = other.HasTrailer;
		}

		public new Truck MyClone()
		{
			return new Truck(this);
		}

		Truck IMyCloneable<Truck>.MyClone()
		{
			return MyClone();
		}

		public override object Clone()
		{
			return MyClone();
		}

		public override string ToString()
		{
			return base.ToString() + $", Capacity = {CapacityTons}t, Trailer = {HasTrailer}";
		}

		
	}
}
