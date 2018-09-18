using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Core.Demandante;
using Core.Esquemas;
using Core.Estudio;
using Core.Mapping;
using BaseDeDatos;

namespace AccesoDatosDemandante
{
    public class UTDemandante : UTBase
    {


       public DemandanteModel GetDemandanteModelByUserId(int id)
        {
            SqlConnection dbCon = new SqlConnection("Data Source=PRODUCCION;Initial Catalog=Prueba;Persist Security Info=True;User ID=sa;Password=Nivelsql*55");
            GestorBD.Repositorio repositorio = new GestorBD.Repositorio(dbCon);
            dtsLecturaDemandantes dts = new dtsLecturaDemandantes();
            string sql = "SELECT d.*, u.Usuario, u.Nombre, u.Apellido1, u.Apellido2, u.TipoUsuario, e.Nombre TipoIndustriaNombre FROM Demandantes d INNER JOIN Usuarios u ON d.IdUsuario = u.Id INNER JOIN Estudios e ON d.NivelEstudios = e.NivelEstudios WHERE d.IdUsuario = @idUsuario";

            SqlParameter param = new SqlParameter("@idUsuario", id);
            DemandanteModel demModel = new DemandanteModel();
            dts.Merge(repositorio.Leer(sql, CommandType.Text, "Demandantes", param));


            if (dts.Demandantes.Rows.Count > 0)
            {
                demModel = MappingLecturaDemandante.ToDemandanteModel(dts.Demandantes, 0);
                return demModel;
            }
            else
            {
                demModel = null;
                return demModel;
            }

        }





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



        public bool GuardarDatosDemandante(Demandante dem)
        {
            Demandante aux = GetDemandanteByUserId(dem.IdUsuario);
            if (aux != null)
                return false;

            //Creo un dataSet de Usuarios y un adaptador
            dtsDemandantes dts = MappingDemandante.ToDtsDemandantes(dem);

            Repo.Guardar(dts);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Demandantes.IdUsuarioColumn, dem.IdUsuario);

            return Repo.Count(dts.Demandantes, parametros) == 1;
        }



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
