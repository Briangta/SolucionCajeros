using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cajeros.Repositorio;

namespace Cajeros.WebApi.Controllers
{
    public class EventoController : ApiController
    {
        RetoEntities db = new RetoEntities();
        public List<Evento> Get()
        {
            return db.Evento.ToList();
        }

        // GET api/<controller>/5
        public Evento Get(int id)
        {
            return db.Evento.Find(id);
        }

        [HttpPost]
        public void Post()
        {
            string datos = Request.Content.ReadAsStringAsync().Result;
            Evento eventos = Newtonsoft.Json.JsonConvert.DeserializeObject<Evento>(datos);
            db.Evento.Add(eventos);
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