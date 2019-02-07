using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiArarsan2.Models
{
    public class Favoriler
    {
        public int UyeID { get; set; }
        public int UrunID { get; set; }
        public string IsLiked { get; set; }
    }
}