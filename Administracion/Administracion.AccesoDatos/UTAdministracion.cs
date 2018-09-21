using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Administracion;
using Core.Esquemas;
using Core.Mapping;
using GestorBD;
using BaseDeDatos;
using System.Data;
using Core.Demandante;
using Core.Empleador;
using System.Data.SqlClient;
using Core.Usuario;

namespace Administracion.AccesoDatos
{
    public class UTAdministracion : UTBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public Administrador EsValido(Administrador admin)
        {
            dtsAdministrador dts = MappingAdministrador.ToDtsAdministrador(admin);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();

            parametros.Add(dts.Administradores.UsuarioColumn, admin.Usuario);
            parametros.Add(dts.Administradores.ContrasenaColumn, admin.Contrasena);

            // Realizamos un merge con la tabla vacia del dtsAdministrador con los resultados de la tabla obtenida
            dtsAdministrador.AdministradoresDataTable dt = (dtsAdministrador.AdministradoresDataTable)Repo.Leer(dts.Administradores, parametros);

            Administrador adm;
            if (dt.Rows.Count > 0)
                adm = MappingAdministrador.ToAdministrador(dt, 0);
            else
                adm = null;

            return adm;
        }





        public bool EliminarUsuario(int idUsuario, int tipoUsuario)
        {
            SqlParameter param = new SqlParameter("@idUsuario", idUsuario);

            if(tipoUsuario == 0)
                Repo.EjecutarProcedimiento("pEliminarUsuarioE", param);
            else
                Repo.EjecutarProcedimiento("pEliminarUsuarioD", param);

            return true;
        }






        public List<OfertaEmpleo> GetAllOfertas()
        {
            List<OfertaEmpleo> result = new List<OfertaEmpleo>();
            dtsOfertaEmpleo dts = new dtsOfertaEmpleo();

            dtsOfertaEmpleo.OfertasEmpleoDataTable dt = (dtsOfertaEmpleo.OfertasEmpleoDataTable) Repo.Leer(dts.OfertasEmpleo);


            int i = 0;
            foreach (DataRow dtRow in dt)
            {
                OfertaEmpleo oferta = new OfertaEmpleo();
                oferta = MappingOfertaEmpleo.ToOfertaEmpleo(dt, i);
                result.Add(oferta);
                i++;
            }
            return result;
        }




        public List<Usuario> GetUsuarios()
        {
            List<Usuario> result = new List<Usuario>();
            dtsUsuarios dts = new dtsUsuarios();


            dtsUsuarios.UsuariosDataTable dt = (dtsUsuarios.UsuariosDataTable)Repo.Leer(dts.Usuarios);


            int i = 0;
            foreach (DataRow dtRow in dt)
            {
                Usuario usuario = new Usuario();
                usuario = MappingUsuario.ToUsuario(dt, i);
                result.Add(usuario);
                i++;
            }
            return result;
        }








        public List<EmpleadorModel> GetEmpleadores()
        {
            List<EmpleadorModel> list = new List<EmpleadorModel>();
            dtsLectura dts = new dtsLectura();
            dts.Merge(this.Repo.Leer("pEmpleadoresLecturaTodos", CommandType.StoredProcedure, dts.Empleadores.TableName));

            for (int i = 0; i < dts.Empleadores.Rows.Count; i++)
            {
                list.Add(dts.Empleadores.ToEmpleadorModelVistaAdmin(i));
            }

            return list;
        }




        public List<DemandanteModel> GetDemandantesInscritosOferta(int idOferta)
        {
            dtsLecturaDemandantes dts = new dtsLecturaDemandantes();
            SqlParameter param = new SqlParameter("@idOferta", idOferta);
            dts.Merge(this.Repo.Leer("pDemandanteModelInscrito", CommandType.StoredProcedure, dts.Demandantes.TableName, param));
            List<DemandanteModel> result = new List<DemandanteModel>();

            int i = 0;
            foreach (DataRow dtRow in dts.Demandantes)
            {
                DemandanteModel demModel = new DemandanteModel();
                demModel = MappingLecturaDemandante.ToDemandanteModelVistaAdmin(dts.Demandantes, i);

                result.Add(demModel);
                i++;
            }
            return result;
        }




        public List<OfertaEmpleo> GetOfertasDeEmpleador(int idEmpleador)
        {
            List<OfertaEmpleo> result = new List<OfertaEmpleo>();
            dtsOfertaEmpleo dts = new dtsOfertaEmpleo();


            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.OfertasEmpleo.IdEmpleadorColumn, idEmpleador);
            dts.Merge(Repo.Leer(dts.OfertasEmpleo, parametros));


            for (int i = 0; i < dts.OfertasEmpleo.Rows.Count; i++)
            {
                OfertaEmpleo oferta = MappingOfertaEmpleo.ToOfertaEmpleo(dts.OfertasEmpleo, i);
                result.Add(oferta);
            }


            return result;
        }





        public List<DemandanteModel> GetDemandantes()
        {
            List<DemandanteModel> list = new List<DemandanteModel>();
            dtsLecturaDemandantes dts = new dtsLecturaDemandantes();
            dts.Merge(this.Repo.Leer("pDemandantesLecturaTodos", CommandType.StoredProcedure, dts.Demandantes.TableName));

            for (int i = 0; i < dts.Demandantes.Rows.Count; i++)
            {
                list.Add(dts.Demandantes.ToDemandanteModelVistaAdmin(i));
            }

            return list;
        }

    }
}
