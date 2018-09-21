using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Administracion;
using Administracion.CapaNegocio;
using Core.Demandante;
using Core.Empleador;
using Core.Usuario;

namespace Administracion.Controllers
{
    public class AdministracionController : Controller
    {


        /// <summary>
        /// Método que llama la capa de negocios para obtener los demandantes de la BD.
        /// </summary>
        /// <returns>Devuelve un result con la lista de objetos DemandanteModel y
        ///          muestra la vista parcial _Demandantes.</returns>
        [HttpPost]
        public ActionResult ObtenerDemandantes()
        {
            NGAdministracion ngAdmin = new NGAdministracion();
            List<DemandanteModel> result = ngAdmin.GetDemandantes();
            return PartialView("~/Views/Administracion/_Demandantes.cshtml", result);
        }



        /// <summary>
        /// Método que llama la capa de negocios para obtener los empleadores de la BD.
        /// </summary>
        /// <returns>Devuelve un result con la lista de objetos EmpleadorModel y
        ///          muestra la vista parcial _Empleadores.</returns>
        [HttpPost]
        public ActionResult ObtenerEmpleadores()
        {
            NGAdministracion ngAdmin = new NGAdministracion();
            List<EmpleadorModel> result = ngAdmin.GetEmpleadores();
            return PartialView("~/Views/Administracion/_Empleadores.cshtml", result);
        }




        /// <summary>
        /// Método que llama la capa de negocios para obtener los usuarios de la BD.
        /// </summary>
        /// <returns>Devuelve un result con la lista de objetos Usuario y
        ///          muestra la vista parcial _Usuarios.</returns>
        [HttpPost]
        public ActionResult ObtenerUsuarios()
        {
            NGAdministracion ngAdmin = new NGAdministracion();
            List<Usuario> result = ngAdmin.GetUsuarios();
            return PartialView("~/Views/Administracion/_Usuarios.cshtml", result);
        }



        /// <summary>
        /// Método que llama la capa de negocios para obtener las ofertas de la BD.
        /// </summary>
        /// <returns>Devuelve un result con la lista de objetos OfertaEmpleo y
        ///          muestra la vista parcial _Ofertas.</returns>
        [HttpPost]
        public ActionResult GetAllOfertas()
        {
            NGAdministracion ngAdmin = new NGAdministracion();

            List<OfertaEmpleo> result = ngAdmin.GetAllOfertas();
            return PartialView("~/Views/Administracion/_Ofertas.cshtml", result);
        }




        // #################################################################################################




        /// <summary>
        /// Método que llama la capa de negocios para obtener los demandantes inscritos en una oferta de empleo pasado por parámetro.
        /// </summary>
        /// <param name="idOferta"></param>
        /// <returns>Devuelve un result con la lista de objetos DemandanteModel y
        ///          muestra la vista parcial _Demandantes.</returns>
        [HttpPost]
        public ActionResult GetDemandantesInscritosOferta(int idOferta)
        {
            NGAdministracion ngOfertaEmpleo = new NGAdministracion();
            List<DemandanteModel> result = ngOfertaEmpleo.GetDemandantesInscritosOferta(idOferta);

            return PartialView("~/Views/Administracion/_Demandantes.cshtml", result);
        }




        /// <summary>
        /// Método que llama la capa de negocios para obtener las ofertas de un empleador pasado por parámetro.
        /// </summary>
        /// <param name="idEmpleador"></param>
        /// <returns>Devuelve un result con la lista de objetos OfertaEmpleo y
        ///          muestra la vista parcial _Ofertas.</returns>
        [HttpPost]
        public ActionResult GetOfertasDeEmpleador(int idEmpleador)
        {
            NGAdministracion ngOfertaEmpleo = new NGAdministracion();
            List<OfertaEmpleo> result = ngOfertaEmpleo.GetOfertasDeEmpleador(idEmpleador);

            return PartialView("~/Views/Administracion/_Ofertas.cshtml", result);
        }





        [HttpPost]
        public JsonResult EliminarUsuario(int idUsuario, int tipoUsuario)
        {
            NGAdministracion ngAdmin = new NGAdministracion();
            bool result = ngAdmin.EliminarUsuario(idUsuario, tipoUsuario);
            
            return Json(result);
        }







        /// <summary>
        /// Método que comprueba que valida el inicio de sesión del Administrador, para ello llama a la BD.
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>Devuelve un JSON con el objeto Adminsitrador recibido de la capa de negocios
        ///          o un JSON(false) si es nulo.</returns>
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
        /// Método que carga la vista correspondiente a su nombre.
        /// </summary>
        /// <returns>Devuelve la vista IndexAdminsitracion (pagina principal del panel de administración).</returns>
        public ActionResult IndexAdministracion()
        {
            return View();
        }




        /// <summary>
        /// Método que carga la vista correspondiente a su nombre.
        /// </summary>
        /// <returns>Devuelve la vista Login (inicio de sesion para el panel de administración).</returns>
        public ActionResult Login()
        {
            return View();
        }
    }
}