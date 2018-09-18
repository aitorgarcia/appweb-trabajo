using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using GestorBD;
using Core.Mapping;
using Core.Esquemas;
using Core.Demandante;
using Core.Estudio;
using BaseDeDatos;


namespace DemandanteAccesoDatos
{
    public class UTDemandante : UTBase
    {

        /// <summary>
        ///  Obtiene un objeto DemandanteModel (llamando al procedimiento 'pDemandantesLectura') a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto DemandanteModel</returns>
        public DemandanteModel GetDemandanteModelByUserId(int id)
        {
            dtsLecturaDemandantes dts = new dtsLecturaDemandantes();
            SqlParameter param = new SqlParameter("@idUsuario", id);
            dts.Merge(this.Repo.Leer("pDemandantesLectura", CommandType.StoredProcedure, dts.Demandantes.TableName, param));
            DemandanteModel demModel = dts.Demandantes.ToDemandanteModel();

            if (dts.Demandantes.Rows.Count > 0)
                return demModel;
            return null;
        }






        /// <summary>
        ///  Obtiene un objeto Demandante a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto Demandante</returns>
        public Demandante GetDemandanteByUserId(int id)
        {
            dtsDemandantes dts = new dtsDemandantes();
            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Demandantes.IdUsuarioColumn, id);

            // Realizamos un merge con la tabla vacia del dtsUsuario con los resultados de la tabla obtenida
            dtsDemandantes.DemandantesDataTable dtDem = (dtsDemandantes.DemandantesDataTable)Repo.Leer(dts.Demandantes, parametros);

            Demandante dem;
            if (dtDem.Rows.Count > 0)
                dem = MappingDemandante.ToDemandante(dtDem, 0);
            else
                dem = null;

            return dem;
        }



        /// <summary>
        ///  Registra en la base de datos los datos del Demandante ofrecido por parámetro.
        /// </summary>
        /// <param name="dem"></param>
        /// <returns>Devuelve un booleano según si se ha realizado correctamente o no.</returns>
        public bool GuardarDatosDemandante(DemandanteModel dem)
        {
            Demandante aux = GetDemandanteByUserId(dem.IdUsuario);
            if (aux != null)
                return false;

            dtsDemandantes dts = MappingDemandante.ToDtsDemandantes(dem);

            Repo.Guardar(dts);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Demandantes.IdUsuarioColumn, dem.IdUsuario);

            return Repo.Count(dts.Demandantes, parametros) == 1;
        }




        /// <summary>
        /// Obtiene todos los niveles de estudios que hay en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Estudio con cada uno de ellos.</returns>
        public List<Estudio> ObtenerEstudios()
        {
            dtsEstudios dts = new dtsEstudios();
            MappingEstudios estMap = new MappingEstudios();

            dts.Merge(Repo.Leer(dts.Estudios));

            List<Core.Estudio.Estudio> result = estMap.VolcarEstudios(dts.Estudios);
            return result;
        }
    }
}
