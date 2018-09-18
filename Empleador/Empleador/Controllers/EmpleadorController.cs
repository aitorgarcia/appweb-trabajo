using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Empleador;
using Core.Login;
using Core.Utilidades;
using Empleador.CapaNegocio;


namespace Empleador.Controllers
{
    public class EmpleadorController : Controller
    {

        /// <summary>
        /// Método cargado inicialmente. Obtiene el id del usuario de la cookie y con el mismo obtiene el Empleador correspondiente
        /// para comprobar si es su primer acceso.
        /// </summary>
        /// <returns>Vista de PrimerAccesoEmpleador o IndexEmpleador dependiendo de si es el primer acceso.</returns>
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Cookies.GetCookie("Id"));
            NGEmpleador ngEmpleador = new NGEmpleador();
            Core.Empleador.Empleador emp = ngEmpleador.GetEmpleadorByUserId(id);

            if (emp == null)
                return RedirectToAction("PrimerAccesoEmpleador");

            return RedirectToAction("IndexEmpleador");
        }



        /// <summary>
        /// Método que se ejecuta al pulsar el botón de guardar los datos en la vista.
        /// Manda el Empleador con su id (obtenida de la cookie) hacia la capa de negocio para guardar sus datos.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>Un archivo JSON con los datos del Empleador guardado o un JSON con
        ///          el valor false si no se ha guardado correctamente.</returns>
        [HttpPost]
        public JsonResult GuardarDatosEmpleador(Core.Empleador.EmpleadorModel emp)
        {
            if (ModelState.IsValid)
            {
                CapaNegocio.NGEmpleador ngEmpleador = new CapaNegocio.NGEmpleador();
                emp.IdUsuario = Convert.ToInt32(Cookies.GetCookie("Id"));

                bool result = ngEmpleador.ValidarDatosEmpleador(emp);

                if (result)
                    return Json(emp);
                return Json(false);
            }
            return Json(false);
        }




        /// <summary>
        /// Método que cambia el estado de una inscripción cuando se rechaza o acepta.
        /// </summary>
        /// <param name="demInscrito"></param>
        /// <returns>Un archivo JSON booleano según si el estado se ha cambiado correctamente.</returns>
        [HttpPost]
        public JsonResult CambiarEstado(Core.Demandante.DemandanteInscritoOferta demInscrito)
        {
            if (ModelState.IsValid)
            {
                CapaNegocio.NGOfertaEmpleo ngOfertaEmpleo = new CapaNegocio.NGOfertaEmpleo();

                bool result = ngOfertaEmpleo.CambiarEstado(demInscrito);

                if (result)
                    return Json(demInscrito);
                return Json(false);
            }
            return Json(false);
        }






        /// <summary>
        /// Método que se ejecuta al pulsar el botón de guardar los datos en la vista.
        /// Manda el Empleador con su id (obtenida de la cookie) hacia la capa de negocio para guardar sus datos.
        /// </summary>
        /// <param name="oferta"></param>
        /// <returns>Un archivo JSON con los datos del Empleador guardado o un JSON con
        ///          el valor false si no se ha guardado correctamente.</returns>
        [HttpPost]
        public JsonResult GuardarDatosOfertaEmpleo(Core.Empleador.OfertaEmpleo oferta)
        {
            if (ModelState.IsValid)
            {
                CapaNegocio.NGOfertaEmpleo ngOfertaEmpleo = new CapaNegocio.NGOfertaEmpleo();
                //ID?

                bool result = ngOfertaEmpleo.ValidarDatosOfertaEmpleo(oferta);

                if (result)
                    return Json(oferta);
                return Json(false);
            }
            return Json(false);
        }







        /// <summary>
        /// Método que se ejecuta al cargar la vista IndexEmpleador. Obtiene los datos del EmpleadorModel para mostrarlos en la vista llamando a la capa de negocio.
        /// </summary>
        /// <returns>Un archivo JSON con los datos del EmpleadorModel que se desea mostrar
        ///          o un JSON con el valor false si no se ha cargado correctamente.</returns>
        [HttpPost]
        public JsonResult ObtenerDatosEmpleadorModel()
        {
            CapaNegocio.NGEmpleador ngEmpleador = new CapaNegocio.NGEmpleador();
            int id = Convert.ToInt32(Cookies.GetCookie("Id"));

            Core.Empleador.EmpleadorModel empModel = ngEmpleador.GetEmpleadorModelByUserId(id);

            if (empModel == null)
                return Json(false);
            return Json(empModel);
        }




        /// <summary>
        /// Método que se ejecuta al cargar la vista PrimerAccesoEmpleador.
        /// Carga las industrias existentes en la base de datos en un droplist de la vista,
        /// para cargarlos llama a la capa de negocio.
        /// </summary>
        /// <returns>Devuelve un archivo JSON con una lista de Industrias si se han recibido correctamente.
        ///          Si no, devuelve un archivo JSON con el valor a false.</returns>
        [HttpPost]
        public JsonResult ObtenerOfertas(int idEmpleador)
        {
            CapaNegocio.NGOfertaEmpleo ngOfertaEmpleo = new CapaNegocio.NGOfertaEmpleo();

            var result = ngOfertaEmpleo.ObtenerOfertas(idEmpleador);

            if (result == null)
                return Json(false);
            return Json(result);
        }





        /// <summary>
        /// Método que se ejecuta al cargar la vista PrimerAccesoEmpleador.
        /// Carga las industrias existentes en la base de datos en un droplist de la vista,
        /// para cargarlos llama a la capa de negocio.
        /// </summary>
        /// <returns>Devuelve un archivo JSON con una lista de Industrias si se han recibido correctamente.
        ///          Si no, devuelve un archivo JSON con el valor a false.</returns>
        [HttpPost]
        public JsonResult ObtenerIndustrias()
        {
            CapaNegocio.NGEmpleador ngEmpleador = new CapaNegocio.NGEmpleador();

            var result = ngEmpleador.ObtenerIndustrias();

            if (result == null)
                return Json(false);
            return Json(result);
        }




        /// <summary>
        /// Método que obtiene los demandantes inscritos en una oferta concreta la cual es pasada por parámetro.
        /// </summary>
        /// <param name="ofertaAux"></param>
        /// <returns>Un archivo JSON booleano según si el estado se ha cambiado correctamente.</returns>
        [HttpPost]
        public JsonResult GetDemandantesInscritosOferta(OfertaEmpleo ofertaAux)
        {
            
            CapaNegocio.NGOfertaEmpleo ngOfertaEmpleo = new CapaNegocio.NGOfertaEmpleo();

            var result = ngOfertaEmpleo.GetDemandantesInscritosOferta(ofertaAux.Id);

            if (result == null)
                return Json(false);
            return Json(result);
        }







        /// <summary>
        /// Muestra la vista IndexEmpleador cuando se loguea un Empleador (y no es su primer acceso).
        /// </summary>
        /// <returns>Devuelve la vista IndexEmpleador</returns>
        public ActionResult IndexEmpleador()
        {
            return View();
        }


        /// <summary>
        /// Muestra la vista PrimerAccesoEmpleador cuando se loguea un Empleador por primera vez.
        /// </summary>
        /// <returns>Devuelve la vista PrimerAccesoEmpleador</returns>
        public ActionResult PrimerAccesoEmpleador()
        {
            return View();
        }

    }

}