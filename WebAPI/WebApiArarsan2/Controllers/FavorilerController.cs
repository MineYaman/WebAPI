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
    public class FavorilerController : ApiController
    {
       
            public string Get()
            {
                ArarsanEntities entities = new ArarsanEntities();
                List<tblFavoriler> s = new List<tblFavoriler>();
                s = entities.tblFavoriler.ToList();
                var json = JsonConvert.SerializeObject(s, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                return json;

            }
            [Route("api/favoriler/{uyeID}")]
            public string Get(int UyeID)
            {
                ArarsanEntities entities = new ArarsanEntities();
                tblFavoriler favori = new tblFavoriler();
                favori = entities.tblFavoriler.SingleOrDefault(x => x.UyeID == UyeID);
                var json = JsonConvert.SerializeObject(favori, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                return json;
            }
            [HttpPost]
            [Route("api/favoriler/favoriekle")]
            public string favoriEkle([FromBody]Favoriler entity)
            {
                ArarsanEntities db = new ArarsanEntities();
                try
                {
                    tblFavoriler dbToSave = new tblFavoriler()
                    {
                        UyeID = entity.UyeID,
                        UrunID = entity.UrunID
                    };

                    db.tblFavoriler.Add(dbToSave);
                    db.SaveChanges();
                    //result.Status = true;

                    return "Favori Ekleme Basarili";
                }
                catch (Exception ex)
                {
                    return "Favori Ekleme Basarisiz" + ex.Message;
                }
            }
        }
    }
