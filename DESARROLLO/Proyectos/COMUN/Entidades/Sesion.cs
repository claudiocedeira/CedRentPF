using System;
using System.Collections.Generic;
using System.Globalization;

namespace CedRentCOMUN.Entidades
{
    [Serializable]
    public class Sesion
    {
        private string ambiente;
        private string cnnStr;
        private CultureInfo cultura;

        public Sesion()
        {
        }

        public string Ambiente
        {
            get
            {
                return ambiente;
            }
            set
            {
                ambiente = value;
            }
        }
        public string CnnStr
        {
            get
            {
                return cnnStr;
            }
            set
            {
                cnnStr = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public CultureInfo Cultura
        {
            get
            {
                return cultura;
            }
            set
            {
                cultura = value;
            }
        }
    }
}