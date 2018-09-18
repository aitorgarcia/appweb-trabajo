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
        /// Método que devuelve una lista con las ofertas de empleo disponibles para el Demandante cuya id se pasa por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve una lista de ofertas de empleo</returns>
        public List<OfertaEmpleo> GetOfertasDisponibles(int id)
        {
            List<OfertaEmpleo> result;
            UTOfertaEmpleoDemandante ut = new UTOfertaEmpleoDemandante();
            return result = _UTOfertaEmpleoDemandante.GetOfertasNOInscritasByDemandanteId(id);
        }




        /// <summary>
        /// Método que inscribe a un demandante en una oferta, llamando a UTOfertaEmpleo.
        /// </summary>
        /// <param name="demInscrito"></param>
        /// <returns>Devuelve un booleano según si se ha realizado correctamente la inscripción.</returns>
        public bool InscribirDemandante(DemandanteInscritoOferta demInscrito)
        {
            return _UTOfertaEmpleoDemandante.InscribirDemandante(demInscrito);
        }




        /// <summary>
        /// Método que devuelve una lista con las ofertas de empleo inscritas para el Demandante cuya id se pasa por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve una lista de ofertas de empleo</returns>
        public List<OfertaEmpleoInscrita> GetOfertasInscritas(int id)
        {
            List<OfertaEmpleoInscrita> result;
            UTOfertaEmpleoDemandante ut = new UTOfertaEmpleoDemandante();
            return result = _UTOfertaEmpleoDemandante.GetOfertasInscritasByDemandanteId(id);
        }



        /// <summary>
        /// Método que desinscribe a un demandante de una oferta, llamando a UTOfertaEmpleo.
        /// </summary>
        /// <param name="demInscrito"></param>
        /// <returns>Devuelve un booleano según si se ha realizado correctamente la desinscripción.</returns>
        /// <returns></returns>
        public bool DesinscribirDemandante(Core.Demandante.DemandanteInscritoOferta demInscrito)
        {
            int idOferta = demInscrito.IdOfertaEmpleo;
            int idDemandante = demInscrito.IdDemandante;

            bool result = _UTOfertaEmpleoDemandante.DesinscribirDemandante(idOferta, idDemandante);
            return result;
        }





        #region PROPIEDADES
        private UTOfertaEmpleoDemandante _utOfertaEmpleoDemandante { get; set; }

        private UTOfertaEmpleoDemandante _UTOfertaEmpleoDemandante
        {
            get
            {
                if (_utOfertaEmpleoDemandante == null)
                {
                    _utOfertaEmpleoDemandante = new UTOfertaEmpleoDemandante();
                }
                return _utOfertaEmpleoDemandante;
            }

            set { }
        }
        #endregion

    }
}
