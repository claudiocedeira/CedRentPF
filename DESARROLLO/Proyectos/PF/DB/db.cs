using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.ExceptionServices;

namespace CedRentPF
{
    public class DB : DBbase
    {
        public DB(CedRentCOMUN.Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<Entidades.ProductoComercial> LeerProductoComercial()
        {
            List<Entidades.ProductoComercial> lista = new List<Entidades.ProductoComercial>();
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("select ProductoComercialId, ProductoComercialDescr from ProductoComercial order by ProductoComercialId ");
            using (DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.ProductoComercial elem = new Entidades.ProductoComercial();
                    elem.Id = Convert.ToInt32(dt.Rows[i]["ProductoComercialId"]);
                    elem.Descr = Convert.ToString(dt.Rows[i]["ProductoComercialDescr"]);
                    lista.Add(elem);
                }
            }
            return lista;
        }
        public double IndiceUVA(DateTime Fecha)
        {
            double valor = -1;
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("select Valor from IndiceUVA where Fecha='" + Fecha.ToString("yyyyMMdd") + "'");
            using (DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr))
            {
                if (dt.Rows.Count == 1) valor = Convert.ToDouble(dt.Rows[0]["Valor"]);
            }
            return valor;
        }
    }
}
