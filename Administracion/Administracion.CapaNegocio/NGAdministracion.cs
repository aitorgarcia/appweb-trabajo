using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Administracion;
using Administracion.AccesoDatos;
using Core.Demandante;
using Core.Empleador;
using Core.Usuario;

namespace Administracion.CapaNegocio
{
    public class NGAdministracion
    {


        public bool EliminarUsuario(int idUsuario, int tipoUsuario)
        {
            UTAdministracion utAdministracion = new UTAdministracion();
            bool result = utAdministracion.EliminarUsuario(idUsuario, tipoUsuario);

            return result;
        }




        public List<DemandanteModel> GetDemandantes(){
            List<DemandanteModel> result = new List<DemandanteModel>();

            UTAdministracion utAdministracion = new UTAdministracion();
            result = utAdministracion.GetDemandantes();

            return result;
        }


        public List<EmpleadorModel> GetEmpleadores()
        {
            List<EmpleadorModel> result = new List<EmpleadorModel>();

            UTAdministracion utAdministracion = new UTAdministracion();
            result = utAdministracion.GetEmpleadores();

            return result;
        }



        public List<Usuario> GetUsuarios()
        {
            List<Usuario> result = new List<Usuario>();

            UTAdministracion utAdministracion = new UTAdministracion();
            result = utAdministracion.GetUsuarios();

            return result;
        }




        public List<OfertaEmpleo> GetOfertasDeEmpleador(int idEmpleador)
        {
            List<OfertaEmpleo> result = new List<OfertaEmpleo>();

            UTAdministracion utAdministracion = new UTAdministracion();
            result = utAdministracion.GetOfertasDeEmpleador(idEmpleador);

            return result;
        }


        public List<DemandanteModel> GetDemandantesInscritosOferta(int idOferta)
        {
            List<DemandanteModel> result = new List<DemandanteModel>();

            UTAdministracion utAdministracion = new UTAdministracion();
            result = utAdministracion.GetDemandantesInscritosOferta(idOferta);

            return result;
        }



        public List<OfertaEmpleo> GetAllOfertas()
        {
            List<OfertaEmpleo> result;
            UTAdministracion utAdmin = new UTAdministracion();
            return result = utAdmin.GetAllOfertas();
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public Administrador EsValido(Administrador admin)
        {
            if (!String.IsNullOrEmpty(admin.Usuario) && !String.IsNullOrEmpty(admin.Contrasena))
            {
                UTAdministracion utAdministracion = new UTAdministracion();

                Administrador adm = utAdministracion.EsValido(admin);
                return adm;
            }
            return null;
        }
    }
}
