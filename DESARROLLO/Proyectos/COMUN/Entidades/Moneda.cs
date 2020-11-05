using System;
using System.Collections.Generic;
using System.Text;

namespace CedRentCOMUN.Entidades
{
    public class Moneda
    {
        string id;
        string descr;

        public Moneda()
        {
        }

        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string Descr
        {
            set
            {
                descr = value;
            }
            get
            {
                return descr;
            }
        }
    }
}
