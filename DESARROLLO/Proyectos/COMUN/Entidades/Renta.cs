using System;

namespace CedRentCOMUN.Entidades
{
	public class Renta
	{
		protected RentaDetalle pesos;
		protected RentaDetalle dolares;

		public Renta()
		{
			pesos = new RentaDetalle();
			dolares = new RentaDetalle();
		}

		public RentaDetalle Pesos
		{
			set
			{
				pesos = value;
			}
			get
			{
				return pesos;
			}
		}
		public RentaDetalle Dolares
		{
			set
			{
				dolares = value;
			}
			get
			{
				return dolares;
			}
		}
	}
}
