using System;

namespace CedRentCOMUN.Entidades
{
	public class RentaDetalle
	{
		protected double importe;
		protected double participacion;
		protected double inversionInicial;

		public RentaDetalle()
		{
		}

		public double Importe
		{
			set
			{
				importe = value;
			}
			get
			{
				return importe;
			}
		}
		public double Participacion
		{
			set
			{
				participacion = value;
			}
			get
			{
				return participacion;
			}
		}
		public double InversionInicial
		{
			set
			{
				inversionInicial = value;
			}
			get
			{
				return inversionInicial;
			}
		}
	}
}

