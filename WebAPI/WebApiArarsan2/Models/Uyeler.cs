using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiArarsan2.Models
{
    public class Uyeler
    {
        public int UyeID { get; set; }
        public string UyeAdi { get; set; }
        public string UyeSoyadi { get; set; }
        public int Telefon { get; set; }
        public string Parola { get; set; }
        public string KullaniciAdi { get; set; }
    }
}