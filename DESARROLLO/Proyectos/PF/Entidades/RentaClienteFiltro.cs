using System;
using System.Collections.Generic;

namespace CedRentPF.Entidades
{
	public class RentaClienteFiltro
	{
		DateTime fecha;
		protected List<PF> pFs;

		public RentaClienteFiltro()
		{
			pFs = new List<PF>();
		}

		public DateTime Fecha
		{
			set
			{
				fecha = value;
			}
			get
			{
				return fecha;
			}
		}
		public List<PF> PFs
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
