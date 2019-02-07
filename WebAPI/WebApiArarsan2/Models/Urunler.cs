using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiArarsan2.Models
{
    public class Urunler
    {
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public int KategoriID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Image { get; set; }

    }
}