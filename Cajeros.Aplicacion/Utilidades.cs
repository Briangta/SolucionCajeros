using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajeros.Aplicacion
{
    public class Utilidades
    {
        public static T consumirRest<T>(object objeto, string url, Method method)
        {
            var clientSpdy = new RestClient(ConfigurationManager.AppSettings["urlRest"].ToString() + url);
            var requestSpdy = new RestRequest(method);

            if (objeto != null)
                requestSpdy.AddParameter("application/json", JsonConvert.SerializeObject(objeto), ParameterType.RequestBody);
            string respuesta = clientSpdy.Execute(requestSpdy).Content;
            var message = JsonConvert.DeserializeObject<T>(respuesta);
            return message;
        }
    }
}
