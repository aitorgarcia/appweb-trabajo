using BaseDeDatos;
using Core.Demandante;
using Core.Empleador;
using Core.Esquemas;
using Core.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemandanteAccesoDatos
{
    public class UTOfertaEmpleoDemandante : UTBase
    {

        /// <summary>
        ///  Obtiene un objeto EmpleadorModel (llamando al procedimiento 'pEmpleadosLectura') a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto EmpleadorModel</returns>
        public List<OfertaEmpleo> GetOfertasNOInscritasByDemandanteId(int id)
        {
            dtsOfertaEmpleo dts = new dtsOfertaEmpleo();
            SqlParameter param = new SqlParameter("@idDemandante", id);
            dts.Merge(this.Repo.Leer("pObtenerOfertasNoInscrito", CommandType.StoredProcedure, dts.OfertasEmpleo.TableName, param));
            List<OfertaEmpleo> result = new List<OfertaEmpleo>();

            int i = 0;
            foreach (DataRow dtRow in dts.OfertasEmpleo)
            {
                OfertaEmpleo oferta = new OfertaEmpleo();
                oferta = MappingOfertaEmpleo.ToOfertaEmpleo(dts.OfertasEmpleo, i);

                result.Add(oferta);
                i++;
            }
            return result;
        }




        /// <summary>
        /// Método que desinscribe al demandante de una oferta en la que esté inscrita.
        /// Llama al procedimiento 'pDesinscribirse' con los datos introducidos por parámetro.
        /// </summary>
        /// <param name="IdOfertaEmpleo"></param>
        /// <param name="IdDemandante"></param>
        /// <returns>Devuelve un booleano que muestra que se ha realizado correctamente.</returns>
        public bool DesinscribirDemandante(int IdOfertaEmpleo, int IdDemandante)
        {
            try
            {
                this.Repo.EjecutarProcedimiento("pDesinscribirse", new SqlParameter("@IdDemandante", IdDemandante), new SqlParameter("@IdOferta", IdOfertaEmpleo));
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        /// <summary>
        /// Método que inscribe al demandante en una oferta disponible.
        /// Crea un nuevo dts con los datos del DemandanteInscritoOferta introducido por parámetro y lo guarda.
        /// </summary>
        /// <param name="demInscrito"></param>
        /// <returns>Devuelve un booleano que muestra que se ha realizado correctamente.</returns>
        public bool InscribirDemandante(DemandanteInscritoOferta demInscrito)
        {
            dtsDemandantesInscritos dts = MappingDemandantesInscritosOferta.ToDtsDemandantesInscritos(demInscrito);

            Repo.Guardar(dts);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.DemandantesInscritosOfertasEmpleo.IdDemandanteColumn, demInscrito.IdDemandante);

            return true;
        }





        /// <summary>
        ///  Obtiene un objeto EmpleadorModel (llamando al procedimiento 'pEmpleadosLectura') a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto EmpleadorModel</returns>
        public List<OfertaEmpleoInscrita> GetOfertasInscritasByDemandanteId(int id)
        {
            dtsOfertaEmpleoInscrita dts = new dtsOfertaEmpleoInscrita();
            SqlParameter param = new SqlParameter("@idDemandante", id);
            dts.Merge(this.Repo.Leer("pInscritosLectura", CommandType.StoredProcedure, dts.pInscritosLectura.TableName, param));
            List<OfertaEmpleoInscrita> result = new List<OfertaEmpleoInscrita>();

            int i = 0;
            foreach (DataRow dtRow in dts.pInscritosLectura)
            {
                OfertaEmpleoInscrita ofertaInscrita = new OfertaEmpleoInscrita();
                ofertaInscrita = MappingOfertaEmpleoInscrita.ToOfertaEmpleoInscrita(dts.pInscritosLectura, i);
                result.Add(ofertaInscrita);
                i++;
            }
            return result;
        }


    }
}
