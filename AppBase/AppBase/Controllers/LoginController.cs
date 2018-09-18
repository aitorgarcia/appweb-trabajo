using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using AppBase.Models;
using Core.Login;
using Core.Usuario;
using Core.Utilidades;

namespace AppBase.Controllers
{
    public class LoginController : Controller
    {

        /// <summary>
        /// Carga la vista inicial del login.
        /// </summary>
        /// <returns>Vista Index de la carpeta Login</returns>
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Método ejecutado al cargar la vista del login.
        /// Comprueba que los campos sean válidos y comprueba que el login se realice correctamente.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Devuelve un archivo JSON con el usuario que ha iniciado sesión
        ///          o un JSON con valor false en su defecto.</returns>
        [HttpPost]
        public JsonResult IniciarSesion(LoginModels usuario)
        {
            //if (ModelState.IsValid)
            //{
                Negocio.NGLogin ngLogin = new Negocio.NGLogin();
                Usuario user = ngLogin.EsValido(usuario);
                //Se añade la cookie con el id para recogerla posteriormente y comprobar que tipo de usuario es.
                if (user == null)
                    return Json(false);
                else
                {
                    Core.Utilidades.Cookies.AddCookie("Id", user.Id.ToString());
                    return Json(user);
                }
                
            //}
           // return Json(false);

        }

    }
}