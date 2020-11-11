using System;
using System.Collections.Generic;

namespace CedRentPF.Entidades
{
	public class PF
	{
		protected ulong nroCertif;
		protected ProductoComercial productoComercial;
		protected CedRentCOMUN.Entidades.Moneda moneda;
		protected double capital;
		protected double tasa;
		protected int plazo;
		protected DateTime fechaConst;
		protected DateTime fechaVto;

		public PF()
		{
			productoComercial = new ProductoComercial();
			moneda = new CedRentCOMUN.Entidades.Moneda();
		}

		public ulong NroCertif
		{
			set
			{
				nroCertif = value;
			}
			get
			{
				return nroCertif;
			}
		}
		public ProductoComercial ProductoComercial
		{
			set
			{
				productoComercial = value;
			}
			get
			{
				return productoComercial;
			}
		}
		public CedRentCOMUN.Entidades.Moneda Moneda
		{
			set
			{
				moneda = value;
			}
			get
			{
				return moneda;
			}
		}
		public double Capital
		{
			set
			{
				capital = value;
			}
			get
			{
				return capital;
			}
		}
		public double Tasa
		{
			set
			{
				tasa = value;
			}
			get
			{
				return tasa;
			}
		}
		public int Plazo
		{
			set
			{
				plazo = value;
			}
			get
			{
				return plazo;
			}
		}
		public DateTime FechaConst
		{
			set
			{
				fechaConst = value;
			}
			get
			{
				return fechaConst;
			}
		}
		public DateTime FechaVto
		{
			set
			{
				fechaVto = value;
			}
			get
			{
				return fechaVto;
			}
		}
		//Propiedades redundantes
		public int ProductoId
		{
			get
			{
				return productoComercial.Id;
			}
		}
		public string ProductoDescr
		{
			get
			{
				return productoComercial.Descr;
			}
		}
		public string MonedaId
		{
			get
			{
				return moneda.Id;
			}
		}
	}
}
