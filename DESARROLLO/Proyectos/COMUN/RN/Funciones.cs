using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CedRentCOMUN.RN
{
	public static class Funciones
	{
		public static string TextoCompletoExcepcion(Exception Excepcion)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(Excepcion.Message);
			while (Excepcion.InnerException != null)
			{
				Excepcion = Excepcion.InnerException;
				sb.Append(" - ");
				sb.Append(Excepcion.Message);
			}
			return sb.ToString();
		}
    }
}