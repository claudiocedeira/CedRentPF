using System;
using System.Collections.Generic;
using System.Globalization;

namespace CedRentPF.RN
{
    public static class RentaPFUVAPrecancelable
    {
        public static CedRentPF.Entidades.RentaPFUVAPrecancelable Obtener(CedRentPF.Entidades.RentaPFUVAPrecancelableFiltro Filtro, CedRentCOMUN.Entidades.Sesion Sesion)
        {
            ValidarFiltro(Filtro);
            CedRentPF.Entidades.RentaPFUVAPrecancelable pF = new Entidades.RentaPFUVAPrecancelable();
            int tiempo = (Filtro.Fecha - Filtro.PF.FechaConst).Days;
            //Calculo renta UVA
            pF.UVA.Renta.Importe = Math.Round(Filtro.PF.Capital * Filtro.PF.Tasa * tiempo / 36500, 2);
            pF.UVA.Renta.Importe += CedRentPF.RN.RentaUVA.CalcularDiferencia(Filtro.PF.Capital, Filtro.PF.FechaConst, Filtro.Fecha, Sesion);
            pF.UVA.Renta.Importe = Math.Round(pF.UVA.Renta.Importe, 2);
            pF.UVA.Renta.Participacion = Math.Round(pF.UVA.Renta.Importe * 100 / Filtro.PF.Capital, 2);
            pF.UVA.Renta.InversionInicial = Filtro.PF.Capital;
            //Calculo renta precancelación
            pF.Precancelacion.Renta.Importe = Math.Round(Filtro.PF.Capital * Filtro.PF.TasaPrecancelacion * tiempo / 36500, 2);
            pF.Precancelacion.Renta.Participacion = Math.Round(pF.Precancelacion.Renta.Importe * 100 / Filtro.PF.Capital, 2);
            pF.Precancelacion.Renta.InversionInicial = Filtro.PF.Capital;
            return pF;
        }
        public static void ValidarFiltro(CedRentPF.Entidades.RentaPFUVAPrecancelableFiltro Filtro)
        {
            if (Filtro.PF.NroCertif == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("NroCertif");
            }
            if (Filtro.PF.ProductoComercial.Id == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("ProductoId");
            }
            if (Filtro.PF.Moneda.Id == string.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("MonedaId");
            }
            if (Filtro.PF.Capital == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Capital");
            }
            if (Filtro.PF.Tasa == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Tasa");
            }
            if (Filtro.PF.Plazo == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Plazo");
            }
            if (Filtro.PF.FechaConst == new DateTime())
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("FechaConst");
            }
            if (Filtro.PF.FechaVto == new DateTime())
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("FechaVto");
            }
            if (Filtro.Fecha < Filtro.PF.FechaConst)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.PF.NoVigenteALaFecha(string.Empty);
            }
            if (Filtro.Fecha > Filtro.PF.FechaVto)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.PF.NoVigenteALaFecha(string.Empty);
            }
            if (Filtro.PF.TasaPrecancelacion == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("TasaPrecancelacion");
            }
        }
    }
}
