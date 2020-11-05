using System;

namespace CedRentPF.Entidades
{
	public class Producto
	{
		protected int id;
		protected string descr;

		public Producto()
		{
		}

		public int Id
		{
			set
			{
				id = value;
			}
			get
			{
				return id;
			}
		}
		public string Descr
		{
			set
			{
				descr = value;
			}
			get
			{
				return descr;
			}
		}
	}
}