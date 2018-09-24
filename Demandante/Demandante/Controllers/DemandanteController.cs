using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Demandante;
using Core.Login;
using Core.Utilidades;
using CapaNegocio;


namespace Demandante.Controllers
{
    public class DemandanteController : Controller
    {



        /// <summary>
        /// Método cargado inicialmente. Obtiene el id del usuario de la cookie y con el mismo obtiene el Demandante correspondiente
        /// para comprobar si es su primer acceso.
        /// </summary>
        /// <returns>Vista de PrimerAccesoDemandante o InicialDemandante dependiendo de si es el primer acceso.</returns>
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Cookies.GetCookie("Id"));
            NGDemandante ngDemandante = new NGDemandante();
            Core.Demandante.Demandante dem = ngDemandante.GetDemandanteByUserId(id);

            if (dem == null)
                return RedirectToAction("PrimerAccesoDemandante");

            return RedirectToAction("InicialDemandante");
        }




        /// <summary>
        /// Método que se ejecuta al pulsar el botón de guardar los datos en la vista.
        /// Manda el Demandante con su id (obtenida de la cookie) hacia la capa de negocio para guardar sus datos.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>Un archivo JSON con los datos del Demandante guardado o un JSON con
        ///          el valor false si no se ha guardado correctamente.</returns>
        [HttpPost]
        public JsonResult GuardarDatosDemandante(Core.Demandante.DemandanteModel dem)
        {
            if (ModelState.IsValid)
            {
                NGDemandante ngDemandante = new NGDemandante();
                dem.IdUsuario = Convert.ToInt32(Cookies.GetCookie("Id"));

                bool result = ngDemandante.ValidarDatosDemandante(dem);

                if (result)
                    return Json(dem);
                return Json(false);
            }
            return Json(false);
        }





        /// <summary>
        /// Método que se ejecuta al pulsar el botón de desisncribirse de una oferta en la que esté inscrito el demandante.
        /// Envía el DemandanteInscritoOferta recibido por parámetro a la capa de negocio.
        /// </summary>
        /// <param name="demInscrito"></param>
        /// <returns>Un archivo JSON booleano dependiendo de si se ha desisncrito correctamente o no.</returns>
        [HttpPost]
        public JsonResult DesinscribirDemandante(DemandanteInscritoOferta demInscrito)
        {
            if (ModelState.IsValid)
            {
                CapaNegocio.NGOfertaEmpleoDemandante ngOfertaEmpleo = new CapaNegocio.NGOfertaEmpleoDemandante();

                bool result = ngOfertaEmpleo.DesinscribirDemandante(demInscrito);

                if (result)
                    return Json(demInscrito);
                return Json(false);
            }
            return Json(false);
        }




        /// <summary>
        /// Método que se ejecuta al pulsar el botón de inscribirse en una oferta que esté disponible para el demandante.
        /// Envía el DemandanteInscritoOferta recibido por parámetro a la capa de negocio.
        /// </summary>
        /// <param name="demInscrito"></param>
        /// <returns>Un archivo JSON booleano dependiendo de si se ha desisncrito correctamente o no.</returns>
        [HttpPost]
        public JsonResult InscribirDemandante(DemandanteInscritoOferta demInscrito)
        {
            if (ModelState.IsValid)
            {
                NGOfertaEmpleoDemandante ngOfertaEmpleo = new NGOfertaEmpleoDemandante();

                bool result = ngOfertaEmpleo.InscribirDemandante(demInscrito);

                if (result)
                    return Json(demInscrito);
                return Json(false);
            }
            return Json(false);
        }







        [HttpPost]
        public JsonResult ModificarDatosUsuario(DemandanteModel demModel)
        {
            if (ModelState.IsValid)
            {
                NGDemandante ngDemandante = new NGDemandante();
                demModel.IdUsuario = Convert.ToInt32(Cookies.GetCookie("Id"));

                bool result = ngDemandante.ValidarDatosModificarUsuario(demModel);

                if (result)
                    return Json(demModel);
                return Json(false);
            }
            return Json(false);
        }




        [HttpPost]
        public JsonResult ModificarDatosDemandante(DemandanteModel demModel)
        {
            if (ModelState.IsValid)
            {
                NGDemandante ngDemandante = new NGDemandante();
                demModel.IdUsuario = Convert.ToInt32(Cookies.GetCookie("Id"));

                bool result = ngDemandante.ValidarDatosModificarDemandante(demModel);

                if (result)
                    return Json(demModel);
                return Json(false);
            }
            return Json(false);
        }








        /// <summary>
        /// Método que muestra las ofertas que el Demandante tiene disponibles para inscribirse.
        /// </summary>
        /// <param name="idDemandante"></param>
        /// <returns>Un archivo JSON booleano dependiendo de si se ha desisncrito correctamente o no.</returns>
        [HttpPost]
        public JsonResult GetOfertasDisponibles(int idDemandante)
        {
            CapaNegocio.NGOfertaEmpleoDemandante ngOfertaEmpleoDem = new CapaNegocio.NGOfertaEmpleoDemandante();

            var result = ngOfertaEmpleoDem.GetOfertasDisponibles(idDemandante);

            if (result == null)
                return Json(false);
            return Json(result);
        }






        /// <summary>
        /// Método que muestra las ofertas en las que el Demandante está ya inscrito.
        /// </summary>
        /// <param name="idDemandante"></param>
        /// <returns>Un archivo JSON booleano dependiendo de si se ha desisncrito correctamente o no.</returns>
        [HttpPost]
        public JsonResult GetOfertasInscritas(int idDemandante)
        {
            CapaNegocio.NGOfertaEmpleoDemandante ngOfertaEmpleoDem = new CapaNegocio.NGOfertaEmpleoDemandante();

            var result = ngOfertaEmpleoDem.GetOfertasInscritas(idDemandante);

            if (result == null)
                return Json(false);
            return Json(result);
        }




        /// <summary>
        /// Método que se ejecuta al cargar la vista InicialDemandante. Obtiene los datos del DemandanteModel para mostrarlos en la vista llamando a la capa de negocio.
        /// </summary>
        /// <returns>Un archivo JSON con los datos del DemandanteModel que se desea mostrar
        ///          o un JSON con el valor false si no se ha cargado correctamente.</returns>
        [HttpPost]
        public ActionResult ObtenerDatosDemandanteModel()
        {
            NGDemandante ngDemandante = new NGDemandante();
            int id = Convert.ToInt32(Cookies.GetCookie("Id"));

            Core.Demandante.DemandanteModel demModel = ngDemandante.GetDemandanteModelByUserId(id);

            return PartialView("~/Views/Demandante/_DatosDemandante.cshtml", demModel);
        }




        /// <summary>
        /// Método que se ejecuta al cargar la vista PrimerAccesoDemandante.
        /// Carga los niveles de estudios existentes en la base de datos en un droplist de la vista,
        /// para cargarlos llama a la capa de negocio.
        /// </summary>
        /// <returns>Devuelve un archivo JSON con una lista de objetos Estudio si se han recibido correctamente.
        ///          Si no, devuelve un archivo JSON con el valor a false.</returns>
        [HttpPost]
        public JsonResult ObtenerEstudios()
        {
            NGDemandante ngDemandante = new NGDemandante();

            var result = ngDemandante.ObtenerEstudios();

            if (result == null)
                return Json(false);
            return Json(result);
        }






        /// <summary>
        /// Muestra la vista InicialDemandante cuando se loguea un Demandante (y no es su primer acceso).
        /// </summary>
        /// <returns>Devuelve la vista InicialDemandante</returns>
        public ActionResult InicialDemandante()
        {
            return View();
        }


        /// <summary>
        /// Muestra la vista PrimerAccesoDemandante cuando se loguea un Demandante por primera vez.
        /// </summary>
        /// <returns>Devuelve la vista PrimerAccesoDemandante</returns>
        public ActionResult PrimerAccesoDemandante()
        {
            return View();
        }
    }
}