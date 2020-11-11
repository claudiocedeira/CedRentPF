using System;

namespace CedRentPF.Entidades
{
	public class ProductoComercial
	{
		protected int id;
		protected string descr;

		public ProductoComercial()
		{
		}

		public int Id
		{
			set
			{
				id = value;
			}
			get
			{
				return id;
			}
		}
		public string Descr
		{
			set
			{
				descr = value;
			}
			get
			{
				return descr;
			}
		}
		public bool EsUVAprecancelable
		{
			get
			{
				return descr.ToLower().IndexOf("uva") != -1 && descr.ToLower().IndexOf("precancelable") != -1;
			}
		}
		public bool EsUVA
		{
			get
			{
				return descr.ToLower().IndexOf("uva") != -1;
			}
		}
	}
}