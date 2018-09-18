using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorBD;
using Core.Esquemas;
using Core.Mapping;
using BaseDeDatos;
using Core.Empleador;
using System.Data;
using Core.Demandante;
using System.Data.SqlClient;

namespace AccesoBaseDeDatos
{
    public class UTOfertaEmpleo : UTBase
    {

        /// <summary>
        ///  Registra en la base de datos los datos de la OfertaEmpleo ofrecido por parámetro.
        /// </summary>
        /// <param name="oferta"></param>
        /// <returns>Devuelve un booleano según si se ha realizado correctamente o no.</returns>
        public bool GuardarDatosOfertaEmpleo(OfertaEmpleo oferta)
        {
            dtsOfertaEmpleo dts = MappingOfertaEmpleo.ToDtsOfertaEmpleo(oferta);
            Repo.Guardar(dts);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.OfertasEmpleo.IdColumn, oferta.Id);

            return Repo.Count(dts.OfertasEmpleo, parametros) == 0;
        }



        /// <summary>
        ///  Obtiene un objeto Empleador a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto Empleador</returns>
        public List<OfertaEmpleo> GetOfertasByIdEmpleador(int idEmpleador)
        {
            dtsOfertaEmpleo dts = new dtsOfertaEmpleo();
            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.OfertasEmpleo.IdEmpleadorColumn, idEmpleador);

            // Realizamos un merge con la tabla vacia del dtsUsuario con los resultados de la tabla obtenida
            dtsOfertaEmpleo.OfertasEmpleoDataTable dtOferta = (dtsOfertaEmpleo.OfertasEmpleoDataTable)Repo.Leer(dts.OfertasEmpleo, parametros);
            List<OfertaEmpleo> result = new List<OfertaEmpleo>();

            int i = 0;
            foreach (DataRow dtRow in dtOferta){
                OfertaEmpleo oferta = new OfertaEmpleo();
                oferta = MappingOfertaEmpleo.ToOfertaEmpleo(dtOferta,i);
                result.Add(oferta);
                i++;
            }

            return result;
        }






        public bool CambiarEstado(int IdOfertaEmpleo, int IdDemandante, int Estado)
        {
            try
            {
                this.Repo.EjecutarProcedimiento("pCambiarEstado", new SqlParameter("@IdDemandante", IdDemandante), new SqlParameter("@IdOferta", IdOfertaEmpleo), new SqlParameter("@Estado", Estado));
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        public List<DemandanteInscritoOferta> GetDemandantesInscritosOferta(int idOferta)
        {
            dtsDemandantesInscritosOferta dts = new dtsDemandantesInscritosOferta();
            SqlParameter param = new SqlParameter("@idOferta", idOferta);
            dts.Merge(this.Repo.Leer("pDemandantesInscritosOferta", CommandType.StoredProcedure, dts.pDemandantesInscritosOferta.TableName, param));
            List<DemandanteInscritoOferta> result = new List<DemandanteInscritoOferta>();

            int i = 0;
            foreach (DataRow dtRow in dts.pDemandantesInscritosOferta)
            {
                DemandanteInscritoOferta demInscrito = new DemandanteInscritoOferta();
                demInscrito = MappingDemandantesInscritosOferta.ToDemandante(dts.pDemandantesInscritosOferta, i);

                result.Add(demInscrito);
                i++;
            }
            return result;
        }

    }
}
