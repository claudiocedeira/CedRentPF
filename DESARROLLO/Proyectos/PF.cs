using System;
using System.Collections.Generic;

namespace CedRentPFtester
{
	public class PF : CedRentPF.Entidades.PFuva
	{
		CedRentCOMUN.Entidades.RentaDetalle renta;

		public PF() : base()
		{
            renta = new CedRentCOMUN.Entidades.RentaDetalle();
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
        public double RentaDetalleImporte
        {
            get
            {
                return renta.Importe;
            }
        }
        public double RentaDetalleParticipacion
        {
            get
            {
                return renta.Participacion;
            }
        }
        public double RentaDetalleInversionInicial
        {
            get
            {
                return renta.InversionInicial;
            }
        }
        public double RentaDetalleMontoAlDia
        {
            get
            {
                return renta.Importe + renta.InversionInicial;
            }
        }
    }
}
