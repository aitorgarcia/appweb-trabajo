using Core.Demandante;
using Core.Empleador;
using DemandanteAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NGOfertaEmpleoDemandante
    {


        /// <summary>
        /// Obtiene todos los tipos de industrias realizando una llamada a UTEmpleador.
        /// </summary>
        /// <returns>Una lista de objetos Industria con cada una de ellas.</returns>
        public List<OfertaEmpleo> GetAllOfertas()
        {
            UTOfertaEmpleoDemandante utOfertaEmpleoDem = new UTOfertaEmpleoDemandante();
            List<OfertaEmpleo> result;
            return result = utOfertaEmpleoDem.GetAllOfertas();
        }



        public List<OfertaEmpleo> GetOfertasDisponibles(int id)
        {
            UTOfertaEmpleoDemandante utOfertaEmpleoDem = new UTOfertaEmpleoDemandante();
            List<OfertaEmpleo> result;
            return result = utOfertaEmpleoDem.GetOfertasNOInscritasByDemandanteId(id);
        }




        public bool InscribirDemandante(DemandanteInscritoOferta demInscrito)
        {
            UTOfertaEmpleoDemandante utOfertaEmpleo = new UTOfertaEmpleoDemandante();

            return utOfertaEmpleo.InscribirDemandante(demInscrito);
        }




        public List<OfertaEmpleoInscrita> GetOfertasInscritas(int id)
        {
            UTOfertaEmpleoDemandante utOfertaEmpleoDem = new UTOfertaEmpleoDemandante();
            List<OfertaEmpleoInscrita> result;
            return result = utOfertaEmpleoDem.GetOfertasInscritasByDemandanteId(id);
        }
    }
}
