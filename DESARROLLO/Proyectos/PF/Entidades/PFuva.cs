using System;
using System.Collections.Generic;

namespace CedRentPF.Entidades
{
	public class PFuva : PF
	{
		protected double tasaPrecancelacion;

		public PFuva() : base()
		{
		}

		public double TasaPrecancelacion
		{
			set
			{
				tasaPrecancelacion = value;
			}
			get
			{
				return tasaPrecancelacion;
			}
		}
	}
}
