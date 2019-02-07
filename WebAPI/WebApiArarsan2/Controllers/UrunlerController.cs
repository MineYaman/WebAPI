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
    public class UrunlerController : ApiController
    {
        public string Get()
        {
            ArarsanEntities entities = new ArarsanEntities();
            List<tblUrunler> s = new List<tblUrunler>();
            s = entities.tblUrunler.ToList();
            var json = JsonConvert.SerializeObject(s, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return json;
        }
        [Route("api/urunler/{UrunID}")]
        public string Get(int UrunID)
        {
            ArarsanEntities entities = new ArarsanEntities();
            tblUrunler urun = new tblUrunler();
            urun = entities.tblUrunler.SingleOrDefault(x => x.UrunID == UrunID);
            var json = JsonConvert.SerializeObject(urun, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return json;
        }
        [HttpPost]
        [Route("api/urunler/urunekle")]
        public string urunEkle([FromBody]Urunler entity)
        {
            ArarsanEntities db = new ArarsanEntities();
            var urunler = db.tblUrunler.ToList().OrderByDescending(m => m.UrunID).FirstOrDefault();
            var ID = 1;
            if(urunler!=null)
            {
                ID = urunler.UrunID + 1;
            }
            try
            {
                tblUrunler dbToSave = new tblUrunler()
                {
                    UrunAdi = entity.UrunAdi,
                    Aciklama = entity.Aciklama,
                    KategoriID = Convert.ToInt32((entity.KategoriID)),
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude,
                    Image = entity.Image,
                    UrunID=ID
                     
                };
                db.tblUrunler.Add(dbToSave);
                db.SaveChanges();
                //result.Status = true;

                return "Ürün Ekleme Basarili";
            }
            catch (Exception ex)
            {
                return "Ürün Ekleme Basarisiz" + ex.Message;
            }
        }
    }
}
