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
        /// Devuelve una lista con las ofertas del Empleador cuya id es introducida por parámetro.
        /// </summary>
        /// <param name="idEmpleador"></param>
        /// <returns>Devuelve una lista de objetos OfertaEmpleo</returns>
        public List<OfertaEmpleo> GetOfertasByIdEmpleador(int idEmpleador)
        {
            dtsOfertaEmpleo dts = new dtsOfertaEmpleo();
            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.OfertasEmpleo.IdEmpleadorColumn, idEmpleador);

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




        /// <summary>
        /// Llama al procedimiento (pCambiarEstado) con los valores introducidos por parámetro para cambiar el estado de una inscripción pendiente a Rechazada o Aceptada.
        /// </summary>
        /// <param name="IdOfertaEmpleo"></param>
        /// <param name="IdDemandante"></param>
        /// <param name="Estado"></param>
        /// <returns>Devuelve un bool (true) para que se sepa que el cambio se ha realizado.</returns>
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




        /// <summary>
        /// Devuelve una lista con los demandantes inscritos en una oferta concreta cuyo id se pasa por parámetro.
        /// </summary>
        /// <param name="idOferta"></param>
        /// <returns>Devuelve una lista de objetos DemandanteInscritoOferta</returns>
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
