using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cajeros.Repositorio;
using Cajeros.Aplicacion;

namespace Cajeros.Web.Controllers
{
    public class SesionController : Controller
    {

        RetoEntities db = new RetoEntities();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(Usuarios usuario)
        {
            string md5 = AccesoSeguridad.ClaveMd5(usuario.Clave);
            Usuarios usuarioEncontrado = db.Usuarios.Where(r => r.Correo == usuario.Correo && r.Clave == md5)
                .FirstOrDefault();
            if (usuarioEncontrado != null) {
                AccesoSeguridad.IniciarSesion(usuarioEncontrado);
                return RedirectToAction("Index","Rutas");
            }

            ModelState.AddModelError("Clave", "Usuario o Clave incorrecto(s)");
            return View();
        }
    }
}