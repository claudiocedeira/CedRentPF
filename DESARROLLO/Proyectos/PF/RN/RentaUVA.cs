using System;
using System.Collections.Generic;
using System.Globalization;

namespace CedRentPF.RN
{
    public static class RentaUVA
    {
        public static double CalcularDiferencia(double Importe, DateTime FechaDsd, DateTime FechaHst, CedRentCOMUN.Entidades.Sesion Sesion)
        {
            double diferencia = 0;
            DB db = new DB(Sesion);
            double indiceDsd = db.IndiceUVA(FechaDsd);
            double indiceHst = db.IndiceUVA(FechaHst);
            double importeActualizado = Math.Round(Importe / indiceDsd * indiceHst, 2);
            diferencia = importeActualizado - Importe;
            return diferencia;
        }
    }
}
