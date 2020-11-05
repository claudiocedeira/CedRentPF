using System;

namespace CedRentCOMUN.RN
{
	public static class Sesion
	{
		public static void Crear(string Ambiente, string CnnStr, System.Globalization.CultureInfo Cultura, CedRentCOMUN.Entidades.Sesion Sesion)
		{
			try
			{
				Sesion.Ambiente = Ambiente;
				Sesion.CnnStr = CnnStr;
				Sesion.Cultura = Cultura;
			}
			catch (Exception ex)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.Crear(ex);
			}
		}
	}
}
