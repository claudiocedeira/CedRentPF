using System;
using System.Collections.Generic;

namespace CedRentPF.Entidades
{
	public class RentaPFuvaFiltro
	{
		protected PFuva pF;

		public RentaPFuvaFiltro()
		{
			pF = new PFuva();
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
