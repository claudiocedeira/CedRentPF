using System;
using System.Collections.Generic;
using System.Globalization;

namespace CedRentPF.RN
{
    public static class RentaPFuva
    {
        public static CedRentPF.Entidades.RentaPFuva Obtener(CedRentPF.Entidades.RentaPFuvaFiltro Filtro, CedRentCOMUN.Entidades.Sesion Sesion)
        {
            ValidarFiltro(Filtro);
            CedRentPF.Entidades.RentaPFuva renta = GenerarContenedor(Filtro, Sesion);
            //for (int iCtaInv = 0; iCtaInv < renta.Cuentas.Count; iCtaInv++)
            //{
            //    for (int iSubCtaInv = 0; iSubCtaInv < renta.Cuentas[iCtaInv].Subcuentas.Count; iSubCtaInv++)
            //    {
            //        for (int iProducto = 0; iProducto < renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Productos.Count; iProducto++)
            //        {
            //            DB db = new DB(Sesion);
            //            db.DeterminarRentaUltimoDia(renta.Cuentas[iCtaInv].Id, renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Id, renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Productos[iProducto].Id, Filtro.Fecha, renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Productos[iProducto].Renta);
            //            ConsolidarTotales(renta, iCtaInv, iSubCtaInv, iProducto);
            //        }
            //    }
            //}
            CalcularParticipacionesConsolidadas(renta);
            return renta;
        }
        public static void ValidarFiltro(CedRentPF.Entidades.RentaPFuvaFiltro Filtro)
        {
            //if (Filtro.Cuentas.Count == 0)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Cuentas");
            //}
            //else
            //{
            //    for (int i = 0; i < Filtro.Cuentas.Count; i++)
            //    {
            //        if (Filtro.Cuentas[i].Id == string.Empty)
            //        {
            //            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("CuentaId en item " + (i + 1).ToString());
            //        }
            //        if (Filtro.Cuentas[i].Subcuentas.Count == 0)
            //        {
            //            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Subcuentas de la Cuenta " + Filtro.Cuentas[i].Id);
            //        }
            //        for (int j = 0; j < Filtro.Cuentas[i].Subcuentas.Count; j++)
            //        {
            //            if (Filtro.Cuentas[i].Subcuentas[j].Id == string.Empty)
            //            {
            //                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("SubcuentaId, en item " + (j + 1).ToString() + ", de la Cuenta " + Filtro.Cuentas[i].Id);
            //            }
            //            if (Filtro.Cuentas[i].Subcuentas[j].Productos.Count == 0)
            //            {
            //                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Productos de la Subuenta " + Filtro.Cuentas[i].Subcuentas[j].Id);
            //            }
            //            for (int k = 0; k < Filtro.Cuentas[i].Subcuentas[j].Productos.Count; k++)
            //            {
            //                if (Filtro.Cuentas[i].Subcuentas[j].Productos[k] == string.Empty)
            //                {
            //                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Producto, en item " + (k + 1).ToString() + ", de la Subcuenta " + Filtro.Cuentas[i].Subcuentas[j].Id);
            //                }
            //            }
            //        }
            //    }
            //}
        }
        private static CedRentPF.Entidades.RentaPFuva GenerarContenedor(CedRentPF.Entidades.RentaPFuvaFiltro Filtro, CedRentCOMUN.Entidades.Sesion Sesion)
        {
            //DB db = new DB(Sesion);
            //Dictionary<string, string> monedaPorProducto = db.MonedaPorProducto();
            CedRentPF.Entidades.RentaPFuva contenedor = new CedRentPF.Entidades.RentaPFuva();
            //for (int i = 0; i < Filtro.Cuentas.Count; i++)
            //{
            //    contenedor.Cuentas.Add(new CedRentCOMUN.Entidades.RentaCtaInv());
            //    contenedor.Cuentas[contenedor.Cuentas.Count - 1].Id = Filtro.Cuentas[i].Id;
            //    for (int j = 0; j < Filtro.Cuentas[i].Subcuentas.Count; j++)
            //    {
            //        contenedor.Cuentas[i].Subcuentas.Add(new CedRentCOMUN.Entidades.RentaSubCtaInv());
            //        contenedor.Cuentas[i].Subcuentas[contenedor.Cuentas[i].Subcuentas.Count - 1].Id = Filtro.Cuentas[i].Subcuentas[j].Id;
            //        for (int k = 0; k < Filtro.Cuentas[i].Subcuentas[j].Productos.Count; k++)
            //        {
            //            contenedor.Cuentas[i].Subcuentas[j].Productos.Add(new CedRentCOMUN.Entidades.RentaProducto());
            //            contenedor.Cuentas[i].Subcuentas[j].Productos[contenedor.Cuentas[i].Subcuentas[j].Productos.Count - 1].Id = Filtro.Cuentas[i].Subcuentas[j].Productos[k];
            //            contenedor.Cuentas[i].Subcuentas[j].Productos[contenedor.Cuentas[i].Subcuentas[j].Productos.Count - 1].MonedaId = monedaPorProducto[Filtro.Cuentas[i].Subcuentas[j].Productos[k]];
            //        }
            //    }
            //}
            return contenedor;
        }
        private static void ConsolidarTotales(CedRentPF.Entidades.RentaPFuva Renta, int iCtaInv, int iSubCtaInv, int iProducto)
        {
            //if (Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Productos[iProducto].MonedaId == "ARS")
            //{
            //    Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Renta.Pesos.Importe += Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Productos[iProducto].Renta.Importe;
            //    Renta.Cuentas[iCtaInv].Renta.Pesos.Importe += Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Productos[iProducto].Renta.Importe;
            //    Renta.Renta.Pesos.Importe += Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Productos[iProducto].Renta.Importe;
            //}
            //else
            //{
            //    Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Renta.Dolares.InversionInicial += Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Productos[iProducto].Renta.InversionInicial;
            //    Renta.Cuentas[iCtaInv].Renta.Dolares.InversionInicial += Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Productos[iProducto].Renta.InversionInicial;
            //    Renta.Renta.Dolares.InversionInicial += Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Productos[iProducto].Renta.InversionInicial;
            //}
        }
        private static void CalcularParticipacionesConsolidadas(CedRentPF.Entidades.RentaPFuva Renta)
        {
            //CalcularParticipacionConsolidada(Renta.Renta.Pesos);
            //CalcularParticipacionConsolidada(Renta.Renta.Dolares);
            //for (int iCtaInv = 0; iCtaInv < Renta.Cuentas.Count; iCtaInv++)
            //{
            //    CalcularParticipacionConsolidada(Renta.Cuentas[iCtaInv].Renta.Pesos);
            //    CalcularParticipacionConsolidada(Renta.Cuentas[iCtaInv].Renta.Dolares);
            //    for (int iSubCtaInv = 0; iSubCtaInv < Renta.Cuentas[iCtaInv].Subcuentas.Count; iSubCtaInv++)
            //    {
            //        CalcularParticipacionConsolidada(Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Renta.Pesos);
            //        CalcularParticipacionConsolidada(Renta.Cuentas[iCtaInv].Subcuentas[iSubCtaInv].Renta.Dolares);
            //    }
            //}
        }
        private static void CalcularParticipacionConsolidada(CedRentCOMUN.Entidades.RentaDetalle RentaDetalle)
        {
            if (RentaDetalle.InversionInicial != 0)
                RentaDetalle.Participacion = Math.Round(RentaDetalle.Importe * 100 / RentaDetalle.InversionInicial, 2);
            else
                RentaDetalle.Participacion = 0;
        }
    }
}
