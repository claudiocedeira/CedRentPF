using System;
using System.Collections.Generic;

namespace CedRentPF.Entidades
{
	public class RentaPFuva
	{
		protected RentaPF rentaUVA;
		protected RentaPF rentaPrecancelacion;

		public RentaPFuva()
		{
			rentaUVA = new RentaPF();
			rentaPrecancelacion = new RentaPF();
		}

		public RentaPF RentaUVA
		{
			set
			{
				rentaUVA = value;
			}
			get
			{
				return rentaUVA;
			}
		}
		public RentaPF RentaPrecancelacion
		{
			set
			{
				rentaPrecancelacion = value;
			}
			get
			{
				return rentaPrecancelacion;
			}
		}
	}
}
