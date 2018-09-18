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
        ///  Obtiene todos los registros de OfertaEmpleo, los guarda en una lista y los devuelve.
        /// </summary>
        /// <returns>Devuelve una lista con objetos OfertaEmpleo</returns>
        public List<OfertaEmpleo> GetAllOfertas()
        {
            dtsOfertaEmpleo dts = new dtsOfertaEmpleo();

            // Realizamos un merge con la tabla vacia del dtsUsuario con los resultados de la tabla obtenida
            dts.Merge(Repo.Leer(dts.OfertasEmpleo));
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
