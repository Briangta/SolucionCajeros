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
    [EnableCors("*", "*", "*")]
    public class RutaController : ApiController
    {
        RetoEntities db = new RetoEntities();
        public List<Cajero> Get()
        {
            List<Cajero> prioritarios = db.Evento.GroupBy(r => r.IdCajero).Select(r => r.OrderByDescending(q=>q.IdEvento).FirstOrDefault())
                .Where(r => (r.Cantidad50 * 50000 + r.Cantidad20 * 20000 + r.Cantidad10 * 10000) < 45000000)
                .Select(r => r.Cajero).ToList();

            List<int> cajerosPrioritariosIds = prioritarios.Select(r => r.IdCajero).ToList();
            //prioritarios
            DateTime desde = DateTime.Now.Date.AddDays(-5);

            List<Cajero> cajeros = db.Comportamiento.Where(r => r.Fecha >= desde).GroupBy(r => r.Cajero)
                .OrderByDescending(r => r.Sum(q => q.Cant50 ?? 0 * 50000)
                + r.Sum(q => q.Cant20 ?? 0 * 50000) + (r.Sum(q => q.Cant10 ?? 0 * 10000))
            - r.Sum(q => q.Pago50 ?? 0 * 50000) + r.Sum(q => q.Cant20 ?? 0 * 20000) + r.Sum(q => q.Cant10 ?? 0 * 10000))
            .Select(r => r.FirstOrDefault()).Select(r => r.Cajero).Where(r => !cajerosPrioritariosIds.Contains(r.IdCajero))
            .ToList();

            prioritarios.AddRange(cajeros);


            cajerosPrioritariosIds = cajeros.Select(r => r.IdCajero).ToList();
            prioritarios.AddRange(db.Cajero.Where(r => !cajerosPrioritariosIds.Contains(r.IdCajero)).ToList());           

            return prioritarios;

        }


        public void Delete(int id)
        {
        }
    }
}