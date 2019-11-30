using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Cajeros.Aplicacion.Enumeradores;
using Cajeros.Repositorio;

namespace Cajeros.Aplicacion
{
    public class AccesoSeguridad : AuthorizeAttribute
    {
        public bool Salir
        {
            get;
            set;
        }

        public static bool PropietarioHistoriaClinica
        {
            get { return (bool)HttpContext.Current.Session["blah"]; }
            set { HttpContext.Current.Session["blah"] = value; }
        }

        /// <summary>
        /// Acceso para los permisos
        /// </summary>
        /// <param name="funcion"> funcion de acceso</param>
        /// <param name="salir">salir = true</param>

        public AccesoSeguridad(bool salir = true)
        {
            this.Salir = salir;
        }

        /// <summary>
        /// Codigo interno de la session de usuario
        /// </summary>
        private const string SesionSeguridadUsuario = "STR_SESSION_SEGURIDAD_USUARIO";



        public static Usuarios PersonaLogueada
        {
            get
            {
                return (Usuarios)HttpContext.Current.Session[SesionSeguridadUsuario];
            }
            set
            {
                HttpContext.Current.Session[SesionSeguridadUsuario] = value;
            }
        }

        /// <summary>
        /// Inicia sesion de usuario
        /// </summary>
        /// <param name="usuarioEncontrado">Objeto de usuario obtenido si la autenticacion fue correcta</param>
        /// <param name="permisos">Lista de Permisos del usuario</param>
        /// <param name="organizacion">Organizacion logueada</param>
        /// <param name="organizaciones">arbol de organizaciones</param>
        public static void IniciarSesion(Usuarios usuarioEncontrado)
        {
            PersonaLogueada = usuarioEncontrado;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            ////Valida la funcion principal si existe el usuario
            return PersonaLogueada != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (this.Salir)
            {
                filterContext.Result = new RedirectToRouteResult(
                       new System.Web.Routing.RouteValueDictionary
                                   {
                                       { "action", "Login" },
                                       { "controller", "Sesion" },
                                       { "area", ""}
                                   });
            }
        }

        
        /// <summary>
        /// Cierra la session y libera todos los recursos
        /// guardados en la session
        /// </summary>
        public static void CerrarSesion()
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session.Clear();
            }
        }

        /// <summary>
        /// Metodo que evalua el md5 de una cadena
        /// </summary>
        /// <param name="clave">Cadena a encriptar en md5</param>
        /// <returns>Retorna un md5 encriptado</returns>
        public static string ClaveMd5(string clave)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(clave);
            data = provider.ComputeHash(data);
            string md5 = string.Empty;
            for (int i = 0; i < data.Length; i++)
                md5 += data[i].ToString("x2").ToLower();

            return md5;
        }        
    }
}


