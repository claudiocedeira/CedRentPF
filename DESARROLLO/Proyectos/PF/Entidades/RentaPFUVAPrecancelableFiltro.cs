using System;
using System.Collections.Generic;

namespace CedRentPF.Entidades
{
	public class RentaPFUVAPrecancelableFiltro
	{
		DateTime fecha;
		protected PFuva pF;

		public RentaPFUVAPrecancelableFiltro()
		{
			pF = new PFuva();
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
		public PFuva PF
		{
			set
			{
				pF = value;
			}
			get
			{
				return pF;
			}
		}
	}
}
