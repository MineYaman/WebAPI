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
    public class KullanicilarController : ApiController
    {
        public string Get()
        {
            ArarsanEntities entities = new ArarsanEntities();
            List<tblUyeler> s = new List<tblUyeler>();
            s = entities.tblUyeler.ToList();
            var json = JsonConvert.SerializeObject(s, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return json;

        }
        [Route("api/kullanicilar/{kullaniciAdi}/{parola}")]
        public string Get(string kullaniciAdi, string parola)
        {
            ArarsanEntities entities = new ArarsanEntities();
            tblUyeler uye = new tblUyeler();
            uye = entities.tblUyeler.SingleOrDefault(x => x.Parola == parola);
            var json = JsonConvert.SerializeObject(uye, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return json;
        }
        [HttpPost]
        [Route("api/uyeler/uyeekle")]
        public string uyeEkle([FromBody]Uyeler entity)
        {
            ArarsanEntities db = new ArarsanEntities();
            var uyeler = db.tblUyeler.ToList().OrderByDescending(m => m.UyeID).FirstOrDefault();
            var ID = 1;
            if (uyeler != null)
            {
                ID = uyeler.UyeID + 1;
            }
            try
            {
                tblUyeler dbToSave = new tblUyeler()
                {
                    UyeAdi = entity.UyeAdi,
                    UyeSoyad = entity.UyeSoyadi,
                    Parola = entity.Parola,
                    Telefon = entity.Telefon,
                    UyeID = ID
                };

                db.tblUyeler.Add(dbToSave);
                db.SaveChanges();
                //result.Status = true;

                return "Üye Ekleme Basarili";
            }
            catch (Exception ex)
            {
                return "Üye Ekleme Basarisiz" + ex.Message;
            }
        }
    }
}
