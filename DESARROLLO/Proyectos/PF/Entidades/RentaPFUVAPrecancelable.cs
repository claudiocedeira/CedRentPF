using System;
using System.Collections.Generic;

namespace CedRentPF.Entidades
{
	public class RentaPFUVAPrecancelable
	{
		protected RentaPF uVA;
		protected RentaPF precancelacion;

		public RentaPFUVAPrecancelable()
		{
			uVA = new RentaPF();
			precancelacion = new RentaPF();
		}

		public RentaPF UVA
		{
			set
			{
				uVA = value;
			}
			get
			{
				return uVA;
			}
		}
		public RentaPF Precancelacion
		{
			set
			{
				precancelacion = value;
			}
			get
			{
				return precancelacion;
			}
		}
	}
}
