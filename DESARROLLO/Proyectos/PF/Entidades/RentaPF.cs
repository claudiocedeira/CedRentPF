using System;
using System.Collections.Generic;
using System.Text;

namespace CedRentPF.Entidades
{
    public class RentaPF
    {
        ulong nroCertif;
        CedRentCOMUN.Entidades.RentaDetalle renta;

        public RentaPF()
        {
            renta = new CedRentCOMUN.Entidades.RentaDetalle();
        }

        public ulong NroCertif
        {
            set
            {
                nroCertif = value;
            }
            get
            {
                return nroCertif;
            }
        }
        public CedRentCOMUN.Entidades.RentaDetalle Renta
        {
            set
            {
                renta = value;
            }
            get
            {
                return renta;
            }
        }
        public double MontoAlDia
        {
            get
            {
                return renta.Importe + renta.InversionInicial;
            }
        }
    }
}
