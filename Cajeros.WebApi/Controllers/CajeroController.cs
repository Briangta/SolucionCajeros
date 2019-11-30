using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cajeros.Repositorio;
using System.Web.Http.Cors;

namespace Cajeros.WebApi.Controllers
{
    [EnableCors("*","*","*")]
    public class CajeroController : ApiController
    {
        RetoEntities db = new RetoEntities();
        public List<Cajero> Get()
        {
            return db.Cajero.ToList();

        }

        // GET api/<controller>/5
        public Cajero Get(int id)
        {
            return db.Cajero.Find(id);

        }

        [HttpPost]
        public void Post()
        {
            string datos = Request.Content.ReadAsStringAsync().Result;
            Cajero cajeros = Newtonsoft.Json.JsonConvert.DeserializeObject<Cajero>(datos);
            db.Cajero.Add(cajeros);
            db.SaveChanges();
            
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}