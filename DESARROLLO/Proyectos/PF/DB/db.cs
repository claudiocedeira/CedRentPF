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
        //public void DeterminarRentaUltimoDia(string CtaInv, string SubCtaInv, string ProductoId, DateTime FechaRef, CedRentCOMUN.Entidades.RentaDetalle Renta)
        //{
        //    StringBuilder a = new StringBuilder(String.Empty);
        //    a.AppendLine("declare @CtaInv varchar(15) ");
        //    a.AppendLine("declare @SubCtaInv varchar(30) ");
        //    a.AppendLine("declare @ProductoId varchar(15) ");
        //    a.AppendLine("declare @FechaRef datetime ");
        //    a.AppendLine("declare @FechaHst datetime ");
        //    a.AppendLine("declare @FechaDsd datetime ");
        //    a.AppendLine("declare @PrecioHst numeric(17, 6) ");
        //    a.AppendLine("declare @PrecioDsd numeric(17, 6) ");
        //    a.AppendLine("declare @CantidadDsd numeric(17, 7) ");
        //    a.AppendLine("declare @CantidadSusc numeric(17, 7) ");
        //    a.AppendLine("declare @PrecioSusc numeric(17, 6) ");
        //    a.AppendLine("declare @CantidadResc numeric(17, 7) ");
        //    a.AppendLine("declare @PrecioResc numeric(17, 6) ");
        //    a.AppendLine("set @CtaInv = '" + CtaInv + "' ");
        //    a.AppendLine("set @SubCtaInv = '" + SubCtaInv + "' ");
        //    a.AppendLine("set @ProductoId = '" + ProductoId + "' ");
        //    a.AppendLine("set @FechaRef = '" + FechaRef.ToString("yyyyMMdd") + "' ");
        //    a.AppendLine("select @FechaHst = max(Fecha) from Precio where Fecha <= @FechaRef ");
        //    a.AppendLine("select @FechaDsd = max(Fecha) from Precio where Fecha < @FechaHst ");
        //    a.AppendLine("select @PrecioHst = Precio.Precio from Precio where Precio.Fecha = @FechaHst and Precio.ProductoId = @ProductoId ");
        //    a.AppendLine("select @PrecioDsd = Precio.Precio from Precio where Precio.Fecha = @FechaDsd and Precio.ProductoId = @ProductoId ");
        //    a.AppendLine("select @CantidadDsd = (select isnull(sum(Susc.Cantidad), 0) from Susc where Susc.Fecha <= @FechaDsd and Susc.ProductoId = @ProductoId and Susc.CtaInv = @CtaInv and Susc.SubCtaInv = @SubCtaInv)-(select isnull(sum(Resc.Cantidad), 0) from Resc where Resc.Fecha <= @FechaDsd and Resc.ProductoId = @ProductoId and Resc.CtaInv = @CtaInv and Resc.SubCtaInv = @SubCtaInv)  ");
        //    a.AppendLine("select @CantidadSusc = isnull(sum(Susc.Cantidad), 0), @PrecioSusc = isnull(sum(Susc.Importe) / sum(Susc.Cantidad), 0) from Susc where Susc.Fecha > @FechaDsd and Susc.Fecha <= @FechaHst and Susc.ProductoId = @ProductoId and Susc.CtaInv = @CtaInv and Susc.SubCtaInv = @SubCtaInv ");
        //    a.AppendLine("select @CantidadResc = isnull(sum(Resc.Cantidad), 0), @PrecioResc = isnull(sum(Resc.Importe) / sum(Resc.Cantidad), 0) from Resc where Resc.Fecha > @FechaDsd and Resc.Fecha <= @FechaHst and Resc.ProductoId = @ProductoId and Resc.CtaInv = @CtaInv and Resc.SubCtaInv = @SubCtaInv ");
        //    a.AppendLine("select @PrecioHst as PrecioHst, @CantidadSusc as CantidadSusc, @PrecioSusc as PrecioSusc, @CantidadResc as CantidadResc, @PrecioResc as PrecioResc, @CantidadDsd as CantidadDsd, @PrecioDsd as PrecioDsd ");
        //    using (DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr))
        //    {
        //        double cantidadHst = Convert.ToDouble(dt.Rows[0]["CantidadDsd"]) + Convert.ToDouble(dt.Rows[0]["CantidadSusc"]) - Convert.ToDouble(dt.Rows[0]["CantidadResc"]);
        //        double MontoDsd = Convert.ToDouble(dt.Rows[0]["CantidadDsd"]) * Convert.ToDouble(dt.Rows[0]["PrecioDsd"]);
        //        double MontoSusc = Convert.ToDouble(dt.Rows[0]["CantidadSusc"]) * Convert.ToDouble(dt.Rows[0]["PrecioSusc"]);
        //        double MontoResc = Convert.ToDouble(dt.Rows[0]["CantidadResc"]) * Convert.ToDouble(dt.Rows[0]["PrecioResc"]);
        //        double MontoHst = cantidadHst * Convert.ToDouble(dt.Rows[0]["PrecioHst"]);
        //        Renta.InversionInicial = Math.Round(MontoDsd + MontoSusc, 2);
        //        Renta.Importe = Math.Round(MontoHst - MontoDsd - MontoSusc + MontoResc, 2);
        //        if (Renta.InversionInicial != 0)
        //            Renta.Participacion = Math.Round(Renta.Importe * 100 / Renta.InversionInicial, 2);
        //        else
        //            Renta.Participacion = 0;
        //    }
        //}
        //public List<Entidades.Resc> RescNoAplic()
        //{
        //    List<Entidades.Resc> lista = new List<Entidades.Resc>();
        //    StringBuilder a = new StringBuilder(String.Empty);
        //    a.AppendLine("select RescId, ProductoId, CtaInv, SubCtaInv, Precio, Cantidad, Importe, Fecha, IdExterno, CantidadNoAplic, Provisorio from Resc where CantidadNoAplic!=0 order by RescId ");
        //    using (DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr))
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            Entidades.Resc elem = new Entidades.Resc();
        //            elem.Id = Convert.ToInt32(dt.Rows[i]["RescId"]);
        //            Copiar(dt.Rows[i], elem);
        //            lista.Add(elem);
        //        }
        //    }
        //    return lista;
        //}
        //public List<Entidades.Susc> SuscNoAplic(Entidades.Resc Resc)
        //{
        //    List<Entidades.Susc> lista = new List<Entidades.Susc>();
        //    StringBuilder a = new StringBuilder(String.Empty);
        //    a.AppendLine("select SuscId, ProductoId, CtaInv, SubCtaInv, Precio, Cantidad, Importe, Fecha, IdExterno, CantidadNoAplic, Provisorio from Susc where CtaInv='" + Resc.CtaInv + "' and SubCtaInv='" + Resc.SubCtaInv + "' and ProductoId='" + Resc.Producto.Id + "' and CantidadNoAplic!=0 order by SuscId ");
        //    using (DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr))
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            Entidades.Susc elem = new Entidades.Susc();
        //            elem.Id = Convert.ToInt32(dt.Rows[i]["SuscId"]);
        //            Copiar(dt.Rows[i], elem);
        //            lista.Add(elem);
        //        }
        //    }
        //    return lista;
        //}
        //private void Copiar(DataRow Desde, Entidades.Movimiento Hasta)
        //{
        //    Hasta.Producto.Id = Convert.ToInt32(Desde["ProductoId"]);
        //    Hasta.CtaInv = Desde["CtaInv"].ToString();
        //    Hasta.SubCtaInv = Desde["SubCtaInv"].ToString();
        //    Hasta.Precio = Convert.ToDouble(Desde["Precio"]);
        //    Hasta.Cantidad = Convert.ToDouble(Desde["Cantidad"]);
        //    Hasta.Importe = Convert.ToDouble(Desde["Importe"]);
        //    Hasta.Fecha = Convert.ToDateTime(Desde["Fecha"]);
        //    Hasta.IdExterno = Desde["IdExterno"].ToString();
        //    Hasta.CantidadNoAplic = Convert.ToDouble(Desde["CantidadNoAplic"]);
        //    Hasta.Provisorio = Convert.ToBoolean(Desde["Provisorio"]);
        //}
        //public void Aplicar(List<Entidades.Aplic> Aplics)
        //{
        //    StringBuilder a = new StringBuilder(String.Empty);
        //    for (int i = 0; i < Aplics.Count; i++)
        //    {
        //        a.AppendLine("update Susc set CantidadNoAplic = CantidadNoAplic - " + Aplics[i].Cantidad.ToString(System.Globalization.CultureInfo.InvariantCulture) + " where SuscId = " + Aplics[i].SuscId.ToString(System.Globalization.CultureInfo.InvariantCulture) + " ");
        //        a.AppendLine("update Resc set CantidadNoAplic = CantidadNoAplic - " + Aplics[i].Cantidad.ToString(System.Globalization.CultureInfo.InvariantCulture) + " where RescId = " + Aplics[i].RescId.ToString(System.Globalization.CultureInfo.InvariantCulture) + " ");
        //        a.AppendLine("insert Aplic values (" + Aplics[i].RescId.ToString() + ", " + Aplics[i].SuscId.ToString() + ", getdate(), " + Aplics[i].Cantidad.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", " + Convert.ToInt32(Aplics[i].Provisorio).ToString() + ") ");
        //    }
        //    Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        //}
        //public List<CedRentCOMUN.Entidades.RentaOrden> RentaPorRealizacion(List<string> IdsExternos)
        //{
        //    List<CedRentCOMUN.Entidades.RentaOrden> lista = new List<CedRentCOMUN.Entidades.RentaOrden>();
        //    StringBuilder a = new StringBuilder(String.Empty);
        //    a.AppendLine("select Resc.Fecha, Resc.RescId, Resc.CtaInv, Resc.SubCtaInv, Resc.ProductoId, Resc.Precio, Resc.Cantidad, Resc.Importe, Resc.IdExterno, Resc.CantidadNoAplic, Resc.Provisorio, ");
        //    a.AppendLine("isnull((select sum(Aplic.Cantidad * Susc.Precio) from Aplic inner join Susc on Susc.SuscId = Aplic.SuscId where Aplic.RescId = Resc.RescId), 0) as InversionInicial ");
        //    a.AppendLine("from Resc ");
        //    a.Append("where Resc.IdExterno in (");
        //    for (int i=0; i<IdsExternos.Count; i++)
        //    {
        //        if (i != 0) a.Append(", ");
        //        a.Append("'" + IdsExternos[i] + "'");
        //    }
        //    a.AppendLine(") ");
        //    a.AppendLine("order by Resc.IdExterno ");
        //    using (DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr))
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                CedRentCOMUN.Entidades.RentaOrden elem = new CedRentCOMUN.Entidades.RentaOrden();
        //                elem.NroOrden = dt.Rows[i]["IdExterno"].ToString();
        //                if (Convert.ToDouble(dt.Rows[i]["InversionInicial"]) != 0)
        //                {
        //                    elem.Renta.InversionInicial = Convert.ToDouble(dt.Rows[i]["InversionInicial"]);
        //                    elem.Renta.Importe = Math.Round(Convert.ToDouble(dt.Rows[i]["Importe"]) - elem.Renta.InversionInicial, 2);
        //                    if (elem.Renta.InversionInicial != 0)
        //                        elem.Renta.Participacion = Math.Round(elem.Renta.Importe * 100 / elem.Renta.InversionInicial, 2);
        //                    else
        //                        elem.Renta.Participacion = 0;
        //                }
        //                else
        //                {
        //                    //No hay detalle de aplicaciones (loguear)
        //                    elem.Renta.InversionInicial = 0;
        //                    elem.Renta.Importe = 0;
        //                    elem.Renta.Participacion = 0;
        //                }
        //                lista.Add(elem);
        //            }
        //        }
        //        else
        //        {
        //            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Orden(es) de Rescate PF ");
        //        }
        //    }
        //    return lista;
        //}
        //public void AjustarPeriodoCalculo(CedRentCOMUN.Entidades.RentaPeriodo RentaPeriodo, string ProductoId)
        //{
        //    StringBuilder a = new StringBuilder(String.Empty);
        //    a.AppendLine("create table #Tramos (FechaDsd datetime, FechaHst datetime) ");
        //    a.AppendLine("declare @FechaDsd datetime ");
        //    a.AppendLine("declare @FechaHst datetime ");
        //    a.AppendLine("select @FechaDsd = max(Fecha) from Precio where Fecha <= '" + RentaPeriodo.Total.PeriodoCalendario.FechaDsd.ToString("yyyyMMdd") + "' and ProductoId='" + ProductoId + "' ");
        //    a.AppendLine("select @FechaHst = max(Fecha) from Precio where Fecha <= '" + RentaPeriodo.Total.PeriodoCalendario.FechaHst.ToString("yyyyMMdd") + "' and ProductoId='" + ProductoId + "' ");
        //    a.AppendLine("insert #Tramos values (@FechaDsd, @FechaHst) ");
        //    for (int i = 0; i < RentaPeriodo.Detalle.Count; i++)
        //    {
        //        a.AppendLine("select @FechaDsd = max(Fecha) from Precio where Fecha <= '" + RentaPeriodo.Detalle[i].PeriodoCalendario.FechaDsd.ToString("yyyyMMdd") + "' and ProductoId='" + ProductoId + "' ");
        //        a.AppendLine("select @FechaHst = max(Fecha) from Precio where Fecha <= '" + RentaPeriodo.Detalle[i].PeriodoCalendario.FechaHst.ToString("yyyyMMdd") + "' and ProductoId='" + ProductoId + "' ");
        //        a.AppendLine("insert #Tramos values (@FechaDsd, @FechaHst) ");
        //    }
        //    a.AppendLine("select FechaDsd, FechaHst from #Tramos ");
        //    using (DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr))
        //    {
        //        for (int i=0; i<dt.Rows.Count; i++)
        //        {
        //            if (i == 0)
        //            {
        //                RentaPeriodo.Total.PeriodoCalculo.FechaDsd = Convert.ToDateTime(dt.Rows[i]["FechaDsd"]);
        //                RentaPeriodo.Total.PeriodoCalculo.FechaHst = Convert.ToDateTime(dt.Rows[i]["FechaHst"]);
        //            }
        //            else
        //            {
        //                RentaPeriodo.Detalle[i - 1].PeriodoCalculo.FechaDsd = Convert.ToDateTime(dt.Rows[i]["FechaDsd"]);
        //                RentaPeriodo.Detalle[i - 1].PeriodoCalculo.FechaHst = Convert.ToDateTime(dt.Rows[i]["FechaHst"]);
        //            }
        //        }
        //    }
        //}
        //public void DeterminarRentaPorPeriodo(string CtaInv, string SubCtaInv, string ProductoId, CedRentCOMUN.Entidades.RentaPeriodo RentaPeriodo)
        //{
        //    List<CedRentCOMUN.Entidades.BorradorTramo> borradorTramos = new List<CedRentCOMUN.Entidades.BorradorTramo>();
        //    StringBuilder a = new StringBuilder(String.Empty);
        //    a.AppendLine("declare @CtaInv varchar(15) ");
        //    a.AppendLine("declare @SubCtaInv varchar(30) ");
        //    a.AppendLine("declare @ProductoId varchar(15) ");
        //    a.AppendLine("declare @FechaHst datetime ");
        //    a.AppendLine("declare @FechaDsd datetime ");
        //    a.AppendLine("declare @PrecioDsd numeric(17, 6) ");
        //    a.AppendLine("declare @CantidadSusc numeric(17, 7) ");
        //    a.AppendLine("declare @PrecioSusc numeric(17, 6) ");
        //    a.AppendLine("declare @CantidadResc numeric(17, 7) ");
        //    a.AppendLine("declare @PrecioResc numeric(17, 6) ");
        //    a.AppendLine("set @CtaInv = '" + CtaInv + "' ");
        //    a.AppendLine("set @SubCtaInv = '" + SubCtaInv + "' ");
        //    a.AppendLine("set @ProductoId = '" + ProductoId + "' ");
        //    a.AppendLine("CREATE TABLE #RentaXPeriodo( ");
        //    a.AppendLine("   CantidadSusc numeric(17, 7) NOT NULL, ");
        //    a.AppendLine("   PrecioSusc numeric(17, 6) NOT NULL, ");
        //    a.AppendLine("   CantidadResc numeric(17, 7) NOT NULL, ");
        //    a.AppendLine("   PrecioResc numeric(17, 6) NOT NULL, ");
        //    a.AppendLine("   PrecioDsd numeric(17, 6) NOT NULL, ");
        //    a.AppendLine(") ");
        //    for (int i=0; i<RentaPeriodo.Detalle.Count; i++)
        //    {
        //        a.AppendLine("set @FechaDsd = '" + RentaPeriodo.Detalle[i].PeriodoCalculo.FechaDsd.ToString("yyyyMMdd") + "' ");
        //        a.AppendLine("set @FechaHst = '" + RentaPeriodo.Detalle[i].PeriodoCalculo.FechaHst.ToString("yyyyMMdd") + "' ");
        //        if (i == 0)
        //        {
        //            a.AppendLine("select (select isnull(sum(Susc.Cantidad), 0) from Susc where Susc.Fecha <= @FechaDsd and Susc.ProductoId = @ProductoId and Susc.CtaInv = @CtaInv and Susc.SubCtaInv = @SubCtaInv)-(select isnull(sum(Resc.Cantidad), 0) from Resc where Resc.Fecha <= @FechaDsd and Resc.ProductoId = @ProductoId and Resc.CtaInv = @CtaInv and Resc.SubCtaInv = @SubCtaInv) as CantidadDsd ");
        //        }
        //        if (i == RentaPeriodo.Detalle.Count - 1)
        //        {
        //            a.AppendLine("select Precio.Precio as PrecioHst from Precio where Precio.Fecha = @FechaHst and Precio.ProductoId = @ProductoId ");
        //        }
        //        a.AppendLine("select @PrecioDsd = Precio.Precio from Precio where Precio.Fecha = @FechaDsd and Precio.ProductoId = @ProductoId ");
        //        a.AppendLine("select @CantidadSusc = isnull(sum(Susc.Cantidad), 0), @PrecioSusc = isnull(sum(Susc.Importe) / sum(Susc.Cantidad), 0) from Susc where Susc.Fecha > @FechaDsd and Susc.Fecha <= @FechaHst and Susc.ProductoId = @ProductoId and Susc.CtaInv = @CtaInv and Susc.SubCtaInv = @SubCtaInv ");
        //        a.AppendLine("select @CantidadResc = isnull(sum(Resc.Cantidad), 0), @PrecioResc = isnull(sum(Resc.Importe) / sum(Resc.Cantidad), 0) from Resc where Resc.Fecha > @FechaDsd and Resc.Fecha <= @FechaHst and Resc.ProductoId = @ProductoId and Resc.CtaInv = @CtaInv and Resc.SubCtaInv = @SubCtaInv ");
        //        a.AppendLine("insert #RentaXPeriodo values (@CantidadSusc, @PrecioSusc, @CantidadResc, @PrecioResc, @PrecioDsd) ");
        //        borradorTramos.Add(new CedRentCOMUN.Entidades.BorradorTramo());
        //    }
        //    a.AppendLine("select CantidadSusc, PrecioSusc, CantidadResc, PrecioResc, PrecioDsd from #RentaXPeriodo ");
        //    using (DataSet ds = (DataSet)Ejecutar(a.ToString(), TipoRetorno.DS, Transaccion.Usa, sesion.CnnStr))
        //    {
        //        borradorTramos[0].CantidadDsd = Convert.ToDouble(ds.Tables[0].Rows[0]["CantidadDsd"]);
        //        borradorTramos[borradorTramos.Count - 1].PrecioHst = Convert.ToDouble(ds.Tables[1].Rows[0]["PrecioHst"]);
        //        for (int i=0; i< ds.Tables[2].Rows.Count; i++)
        //        {
        //            borradorTramos[i].CantidadSusc = Convert.ToDouble(ds.Tables[2].Rows[i]["CantidadSusc"]);
        //            borradorTramos[i].PrecioSusc = Convert.ToDouble(ds.Tables[2].Rows[i]["PrecioSusc"]);
        //            borradorTramos[i].CantidadResc = Convert.ToDouble(ds.Tables[2].Rows[i]["CantidadResc"]);
        //            borradorTramos[i].PrecioResc = Convert.ToDouble(ds.Tables[2].Rows[i]["PrecioResc"]);
        //            borradorTramos[i].PrecioDsd = Convert.ToDouble(ds.Tables[2].Rows[i]["PrecioDsd"]);
        //        }
        //        for (int i = 0; i < borradorTramos.Count; i++)
        //        {
        //            borradorTramos[i].CantidadHst = borradorTramos[i].CantidadDsd + borradorTramos[i].CantidadSusc - borradorTramos[i].CantidadResc;
        //            if (i != (borradorTramos.Count - 1))
        //            {
        //                borradorTramos[i].PrecioHst = borradorTramos[i + 1].PrecioDsd;
        //                borradorTramos[i + 1].CantidadDsd = borradorTramos[i].CantidadHst;
        //            }
        //        }
        //        double MontoHstTotal = 0;
        //        double MontoSuscTotal = 0;
        //        double MontoRescTotal = 0;
        //        double MontoDsdTotal = 0;
        //        for (int i=0; i<borradorTramos.Count; i++)
        //        {
        //            double MontoDsd = borradorTramos[i].CantidadDsd * borradorTramos[i].PrecioDsd;
        //            double MontoHst = borradorTramos[i].CantidadHst * borradorTramos[i].PrecioHst;
        //            if (i == 0)
        //            {
        //                MontoDsdTotal = MontoDsd;
        //            }
        //            if (!RentaPeriodo.Detalle[i].PeriodoCalculo.FechaDsd.Equals(RentaPeriodo.Detalle[i].PeriodoCalculo.FechaHst))
        //            {
        //                double MontoSusc = borradorTramos[i].CantidadSusc * borradorTramos[i].PrecioSusc;
        //                double MontoResc = borradorTramos[i].CantidadResc * borradorTramos[i].PrecioResc;
        //                RentaPeriodo.Detalle[i].Renta.InversionInicial = Math.Round(MontoDsd + MontoSusc, 2);
        //                RentaPeriodo.Detalle[i].Renta.Importe = Math.Round(MontoHst - MontoDsd - MontoSusc + MontoResc, 2);
        //                TimeSpan tiempo = RentaPeriodo.Detalle[i].PeriodoCalculo.FechaHst.Subtract(RentaPeriodo.Detalle[i].PeriodoCalculo.FechaDsd);
        //                if (RentaPeriodo.Detalle[i].Renta.InversionInicial != 0)
        //                {
        //                    RentaPeriodo.Detalle[i].Renta.Participacion = Math.Round(RentaPeriodo.Detalle[i].Renta.Importe * 100 / RentaPeriodo.Detalle[i].Renta.InversionInicial, 2);
        //                }
        //                else
        //                {
        //                    RentaPeriodo.Detalle[i].Renta.Participacion = 0;
        //                }
        //                MontoSuscTotal += MontoSusc;
        //                MontoRescTotal += MontoResc;
        //            }
        //            if (i == (borradorTramos.Count - 1))
        //            {
        //                MontoHstTotal = MontoHst;
        //            }
        //        }
        //        TimeSpan tiempoTotal = RentaPeriodo.Total.PeriodoCalculo.FechaHst.Subtract(RentaPeriodo.Total.PeriodoCalculo.FechaDsd);
        //        RentaPeriodo.Total.Renta.InversionInicial = Math.Round(MontoDsdTotal + MontoSuscTotal, 2);
        //        RentaPeriodo.Total.Renta.Importe = Math.Round(MontoHstTotal - MontoDsdTotal - MontoSuscTotal + MontoRescTotal, 2);
        //        if (RentaPeriodo.Total.Renta.InversionInicial != 0)
        //        {
        //            RentaPeriodo.Total.Renta.Participacion = Math.Round(RentaPeriodo.Total.Renta.Importe * 100 / RentaPeriodo.Total.Renta.InversionInicial, 2);
        //        }
        //        else
        //        {
        //            RentaPeriodo.Total.Renta.Participacion = 0;
        //        }
        //    }
        //}
        //public Dictionary<string, string> MonedaPorProducto()
        //{
        //    Dictionary<string, string> lista = new Dictionary<string, string>();
        //    StringBuilder a = new StringBuilder(String.Empty);
        //    a.AppendLine("select ProductoId, MonedaId from Producto ");
        //    using (DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr))
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            lista.Add(dt.Rows[i]["ProductoId"].ToString(), dt.Rows[i]["MonedaId"].ToString());
        //        }
        //    }
        //    return lista;
        //}
    }
}
