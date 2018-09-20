using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Administracion;
using Administracion.CapaNegocio;
using Core.Demandante;
using Core.Empleador;

namespace Administracion.Controllers
{
    public class AdministracionController : Controller
    {



        [HttpPost]
        public ActionResult ObtenerDemandantes()
        {
            NGAdministracion ngAdmin = new NGAdministracion();
            List<DemandanteModel> result = ngAdmin.GetDemandantes();
            return PartialView("~/Views/Administracion/_Demandantes.cshtml", result);
        }


        [HttpPost]
        public ActionResult ObtenerEmpleadores()
        {
            NGAdministracion ngAdmin = new NGAdministracion();
            List<EmpleadorModel> result = ngAdmin.GetEmpleadores();
            return PartialView("~/Views/Administracion/_Empleadores.cshtml", result);
        }







        [HttpPost]
        public ActionResult GetDemandantesInscritosOferta(int idOferta)
        {
            NGAdministracion ngOfertaEmpleo = new NGAdministracion();
            List<DemandanteModel> result = ngOfertaEmpleo.GetDemandantesInscritosOferta(idOferta);

            return PartialView("~/Views/Administracion/_Demandantes.cshtml", result);
        }





        [HttpPost]
        public ActionResult GetOfertasDeEmpleador(int idEmpleador)
        {
            NGAdministracion ngOfertaEmpleo = new NGAdministracion();
            List<OfertaEmpleo> result = ngOfertaEmpleo.GetOfertasDeEmpleador(idEmpleador);

            return PartialView("~/Views/Administracion/_Ofertas.cshtml", result);
        }




        [HttpPost]
        public ActionResult GetAllOfertas()
        {
            NGAdministracion ngAdmin = new NGAdministracion();

            var result = ngAdmin.GetAllOfertas();
            return PartialView("~/Views/Administracion/_Ofertas.cshtml", result);
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult IniciarSesion(Administrador admin)
        {
            NGAdministracion ngAdmin = new NGAdministracion();
            Administrador adm = ngAdmin.EsValido(admin);
            if (adm == null)
                return Json(false);
            return Json(adm);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexAdministracion()
        {
            return View();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
    }
}