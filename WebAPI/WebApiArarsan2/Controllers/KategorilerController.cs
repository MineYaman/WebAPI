using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiArarsan2.Models;

namespace WebApiArarsan2.Controllers
{
    public class KategorilerController : ApiController
    {
        public string Get()
        {
            ArarsanEntities entities = new ArarsanEntities();
            List<tblKategoriler> s = new List<tblKategoriler>();
            s = entities.tblKategoriler.ToList();
            var json = JsonConvert.SerializeObject(s, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return json;

        }
        [Route("api/kategoriler/{kategoriID}")]
        public string Get(int KategoriID)
        {
            ArarsanEntities entities = new ArarsanEntities();
            tblKategoriler kategori = new tblKategoriler();
            kategori = entities.tblKategoriler.SingleOrDefault(x => x.KategoriID == KategoriID);
            var json = JsonConvert.SerializeObject(kategori, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return json;
        }

    }
}
