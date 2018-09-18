using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using AppBase.Models;
using Core.Registro;

namespace AppBase.Controllers
{
    public class RegistroController : Controller
    {


        /// <summary>
        /// Carga la vista inicial del registro.
        /// </summary>
        /// <returns>Vista Index de la carpeta Registro</returns>
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Comprueba que el usuario sea registrable con los datos introducidos en el formulario.
        /// </summary>
        /// <returns>Un JSON con valor booleano según si se ha registrado o no.</returns>
        [HttpPost]
        public JsonResult RegistrarUsuario(RegistroModels usuario)
        {

            if (ModelState.IsValid)
            {
                Negocio.NGRegistro ngRegistro = new Negocio.NGRegistro();
                if (ngRegistro.EsRegistrable(usuario))
                {
                    return Json(true);
                }
                return Json(false);
            }
            return Json(false);
        }



        public ActionResult RegistroCorrecto()
        {
            return View();
        }

        public ActionResult ErrorRegistro()
        {
            return View();
        }


    }
}