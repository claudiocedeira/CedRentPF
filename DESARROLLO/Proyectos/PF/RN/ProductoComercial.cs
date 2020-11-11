using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

namespace CedRentPF.RN
{
    public static class ProductoComercial
    {
        public static List<Entidades.ProductoComercial> Leer(CedRentCOMUN.Entidades.Sesion Sesion)
        {
            DB db = new DB(Sesion);
            return db.LeerProductoComercial();
        }
    }
}
