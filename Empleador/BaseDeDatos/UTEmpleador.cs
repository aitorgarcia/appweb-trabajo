using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Usuario;
using Core.Login;
using System.Data;
using System.Data.SqlClient;
using GestorBD;
using Core.Esquemas;
using Core.Mapping;
using BaseDeDatos;
using Core.Empleador;

namespace AccesoBaseDeDatos
{
    public class UTEmpleador : UTBase
    {

        /// <summary>
        ///  Obtiene un objeto EmpleadorModel (llamando al procedimiento 'pEmpleadosLectura') a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto EmpleadorModel</returns>
        public EmpleadorModel GetEmpleadorModelByUserId(int id)
        {
            dtsLectura dts = new dtsLectura();
            SqlParameter param = new SqlParameter("@idUsuario",id);
            dts.Merge(this.Repo.Leer("pEmpleadosLectura", CommandType.StoredProcedure, dts.Empleadores.TableName, param));
            EmpleadorModel empModel = dts.Empleadores.ToEmpleadorModel();

            if (dts.Empleadores.Rows.Count > 0)
                return empModel;
            return null;
        }


        /// <summary>
        ///  Obtiene un objeto Empleador a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto Empleador</returns>
        public Empleador GetEmpleadorByUserId(int id)
        {          
            dtsEmpleadores dts = new dtsEmpleadores();
            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Empleadores.IdUsuarioColumn, id);

            // Realizamos un merge con la tabla vacia del dtsUsuario con los resultados de la tabla obtenida
            dtsEmpleadores.EmpleadoresDataTable dtEmp = (dtsEmpleadores.EmpleadoresDataTable)Repo.Leer(dts.Empleadores, parametros);

            Empleador emp;
            if (dtEmp.Rows.Count > 0)
                emp = MappingEmpleador.ToEmpleador(dtEmp, 0);
            else
                emp = null;

            return emp; 
        }



        /// <summary>
        ///  Registra en la base de datos los datos del Empleador ofrecido por parámetro.
        /// </summary>
        /// <param name="empModel"></param>
        /// <returns>Devuelve un booleano según si se ha realizado correctamente o no.</returns>
        public bool GuardarDatosEmpleador(EmpleadorModel empModel)
        {
            Empleador aux = GetEmpleadorByUserId(empModel.IdUsuario);
            if (aux != null)
                return false;

            dtsEmpleadores dts = MappingEmpleador.ToDtsEmpleadores(empModel);

            Repo.Guardar(dts);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Empleadores.IdUsuarioColumn, empModel.IdUsuario);

            return Repo.Count(dts.Empleadores, parametros) == 1;
        }



        /// <summary>
        /// Obtiene todos los tipos de industrias que hay en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Industria con cada una de ellas.</returns>
        public List<Core.Industria.Industria> ObtenerIndustrias()
        {
            dtsIndustrias dts = new dtsIndustrias();
            MappingIndustrias indMap = new MappingIndustrias();

            dts.Merge(Repo.Leer(dts.Industrias));

            List<Core.Industria.Industria> result = indMap.VolcarIndustrias(dts.Industrias);
            return result;
        }

    }
}
