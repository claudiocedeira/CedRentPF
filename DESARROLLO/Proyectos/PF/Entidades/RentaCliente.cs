using System;
using System.Collections.Generic;

namespace CedRentPF.Entidades
{
	public class RentaCliente
	{
		protected CedRentCOMUN.Entidades.Renta rentaUltimoDia;
		List<Entidades.RentaPF> pFs;

		public RentaCliente()
		{
			rentaUltimoDia = new CedRentCOMUN.Entidades.Renta();
			pFs = new List<RentaPF>();
		}

		public CedRentCOMUN.Entidades.Renta RentaUltimoDia
		{
			set
			{
				rentaUltimoDia = value;
			}
			get
			{
				return rentaUltimoDia;
			}
		}
		public List<Entidades.RentaPF> PFs
		{
			set
			{
				pFs = value;
			}
			get
			{
				return pFs;
			}
		}
	}
}
