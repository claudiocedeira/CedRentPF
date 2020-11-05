using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CedRentPFtester
{
    static class Aplicacion
    {
        public static CedRentCOMUN.Entidades.Sesion Sesion;[STAThread]
        static void Main()
        {
			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				Sesion = new CedRentCOMUN.Entidades.Sesion();
				Sesion.CnnStr = System.Configuration.ConfigurationManager.AppSettings["CnnStr"];
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new CedRentPFtesterForm());
			}
			catch (Exception ex)
			{
				MessageBox.Show(CedRentCOMUN.RN.Funciones.TextoCompletoExcepcion(ex), "AVISO DE EXCEPCIÓN");
			}
			finally
			{
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}
    }
}
