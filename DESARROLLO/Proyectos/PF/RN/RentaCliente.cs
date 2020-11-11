using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

namespace CedRentPF.RN
{
    public static class RentaCliente
    {
        public static CedRentPF.Entidades.RentaCliente Obtener(CedRentPF.Entidades.RentaClienteFiltro Filtro, CedRentCOMUN.Entidades.Sesion Sesion)
        {
            ValidarFiltro(Filtro);
            CedRentPF.Entidades.RentaCliente rentaCliente = new Entidades.RentaCliente();
            List<CedRentPF.Entidades.ProductoComercial> productosComerciales = CedRentPF.RN.ProductoComercial.Leer(Sesion);
            for (int i=0; i<Filtro.PFs.Count; i++)
            {
                CedRentPF.Entidades.ProductoComercial productoComercial = productosComerciales.Find(delegate (CedRentPF.Entidades.ProductoComercial p) { return (p.Id == Filtro.PFs[i].ProductoComercial.Id); });
                if (productoComercial != null) Filtro.PFs[i].ProductoComercial.Descr = productoComercial.Descr;
                Entidades.RentaPF pF = new Entidades.RentaPF();
                pF.NroCertif = Filtro.PFs[i].NroCertif;
                //Calculo renta acumulada al dia de la fecha
                int tiempo = (Filtro.Fecha - Filtro.PFs[i].FechaConst).Days;
                pF.Renta.Importe = Math.Round(Filtro.PFs[i].Capital * Filtro.PFs[i].Tasa * tiempo / 36500, 2);
                if (Filtro.PFs[i].ProductoComercial.EsUVA)
                {
                    pF.Renta.Importe += CedRentPF.RN.RentaUVA.CalcularDiferencia(Filtro.PFs[i].Capital, Filtro.PFs[i].FechaConst, Filtro.Fecha, Sesion);
                    pF.Renta.Importe = Math.Round(pF.Renta.Importe, 2);
                }
                pF.Renta.Participacion = Math.Round(pF.Renta.Importe * 100 / Filtro.PFs[i].Capital, 2);
                pF.Renta.InversionInicial = Filtro.PFs[i].Capital;
                rentaCliente.PFs.Add(pF);
                //Calculo renta último dia
                double importeUltimoDia = Math.Round(Filtro.PFs[i].Capital * Filtro.PFs[i].Tasa * 1 / 36500, 2);
                if (Filtro.PFs[i].ProductoComercial.EsUVA)
                {
                    importeUltimoDia += CedRentPF.RN.RentaUVA.CalcularDiferencia(Filtro.PFs[i].Capital, Filtro.Fecha.AddDays(-1), Filtro.Fecha, Sesion);
                    importeUltimoDia = Math.Round(importeUltimoDia, 2);
                }
                double inversionInicialUltimoDia = Filtro.PFs[i].Capital;
                if (Filtro.PFs[i].Moneda.Id == "ARS")
                {
                    rentaCliente.RentaUltimoDia.Pesos.Importe += importeUltimoDia;
                    rentaCliente.RentaUltimoDia.Pesos.InversionInicial += inversionInicialUltimoDia;
                }
                else
                {
                    rentaCliente.RentaUltimoDia.Dolares.Importe += importeUltimoDia;
                    rentaCliente.RentaUltimoDia.Dolares.InversionInicial += inversionInicialUltimoDia;
                }
            }
            if (rentaCliente.RentaUltimoDia.Pesos.InversionInicial != 0)
                rentaCliente.RentaUltimoDia.Pesos.Participacion = Math.Round(rentaCliente.RentaUltimoDia.Pesos.Importe * 100 / rentaCliente.RentaUltimoDia.Pesos.InversionInicial, 2);
            else
                rentaCliente.RentaUltimoDia.Pesos.Participacion = 0;
            if (rentaCliente.RentaUltimoDia.Dolares.InversionInicial != 0)
                rentaCliente.RentaUltimoDia.Dolares.Participacion = Math.Round(rentaCliente.RentaUltimoDia.Dolares.Importe * 100 / rentaCliente.RentaUltimoDia.Dolares.InversionInicial, 2);
            else
                rentaCliente.RentaUltimoDia.Dolares.Participacion = 0;
            return rentaCliente;
        }
        public static void ValidarFiltro(CedRentPF.Entidades.RentaClienteFiltro Filtro)
        {
            if (Filtro.PFs.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("PFs");
            }
            else
            {
                for (int i = 0; i < Filtro.PFs.Count; i++)
                {
                    if (Filtro.PFs[i].NroCertif == 0)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("NroCertif en item " + (i + 1).ToString());
                    }
                    if (Filtro.PFs[i].ProductoComercial.Id == 0)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("ProductoId en item " + (i + 1).ToString());
                    }
                    if (Filtro.PFs[i].Moneda.Id == string.Empty)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("MonedaId en item " + (i + 1).ToString());
                    }
                    if (Filtro.PFs[i].Capital == 0)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Capital en item " + (i + 1).ToString());
                    }
                    if (Filtro.PFs[i].Tasa == 0)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Tasa en item " + (i + 1).ToString());
                    }
                    if (Filtro.PFs[i].Plazo == 0)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Plazo en item " + (i + 1).ToString());
                    }
                    if (Filtro.PFs[i].FechaConst == new DateTime())
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("FechaConst en item " + (i + 1).ToString());
                    }
                    if (Filtro.PFs[i].FechaVto == new DateTime())
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("FechaVto en item " + (i + 1).ToString());
                    }
                    if (Filtro.Fecha <Filtro.PFs[i].FechaConst)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.PF.NoVigenteALaFecha("en item " + (i + 1).ToString());
                    }
                    if (Filtro.Fecha > Filtro.PFs[i].FechaVto)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.PF.NoVigenteALaFecha("en item " + (i + 1).ToString());
                    }
                }
            }
        }
    }
}
