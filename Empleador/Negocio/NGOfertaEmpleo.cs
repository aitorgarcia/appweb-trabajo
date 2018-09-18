using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Usuario;
using Core.Login;
using AccesoBaseDeDatos;
using Core.Empleador;
using Core.Industria;
using Core.Demandante;

namespace Empleador.CapaNegocio
{
    public class NGOfertaEmpleo
    {

        /// <summary>
        ///  Comprueba que los datos de la OfertaEmpleo sean válidos y en caso de serlo llama al UTOfertaEmpleo para guardar sus datos.
        /// </summary>
        /// <param name="oferta"></param>
        /// <returns>Devuelve un booleano dependiendo de si los datos son válidos, o de la llamada a UTOfertaEmpleo.</returns>
        public bool ValidarDatosOfertaEmpleo(Core.Empleador.OfertaEmpleo oferta)
        {
            bool result = _UTOfertaEmpleo.GuardarDatosOfertaEmpleo(oferta);
            return result;
        }




        /// <summary>
        /// Método que recibe un DemandanteInscritoOferta, de él obtiene sus datos y llama al método de UTOfertaEmpleo.
        /// </summary>
        /// <param name="demInscrito"></param>
        /// <returns>Devuelve un booleano según si se ha logrado cambiar el estado se ha cambiado o no.</returns>
        public bool CambiarEstado(Core.Demandante.DemandanteInscritoOferta demInscrito)
        {
            int idOferta = demInscrito.IdOfertaEmpleo;
            int estado = demInscrito.Estado;
            int idDemandante = demInscrito.IdDemandante;

            bool result = _UTOfertaEmpleo.CambiarEstado(idOferta, idDemandante, estado);
            return result;
        }





        /// <summary>
        /// Obtiene todas las ofertas de un Empleador realizando una llamada a UTOfertaEmpleo.
        /// </summary>
        /// <returns>Una lista de objetos OfertaEmpleo con cada una de ellas.</returns>
        public List<OfertaEmpleo> ObtenerOfertas(int idEmpleador)
        {   
            List<OfertaEmpleo> result;
            return result = _UTOfertaEmpleo.GetOfertasByIdEmpleador(idEmpleador);
        }





        /// <summary>
        /// Método que obtiene los demandantes inscritos en una oferta, para ello llama al método de UTOfertaEmpleo.
        /// </summary>
        /// <param name="idOferta"></param>
        /// <returns>Devuelve una lista de objetos DemandanteInscritoOferta.</returns>
        public List<DemandanteInscritoOferta> GetDemandantesInscritosOferta(int idOferta)
        {
            List<DemandanteInscritoOferta> result;
            return result = _UTOfertaEmpleo.GetDemandantesInscritosOferta(idOferta);
        }






        #region PROPIEDADES
        private UTOfertaEmpleo _utOfertaEmpleo { get; set; }

        private UTOfertaEmpleo _UTOfertaEmpleo
        {
            get
            {
                if (_utOfertaEmpleo == null)
                {
                    _utOfertaEmpleo = new UTOfertaEmpleo();
                }
                return _utOfertaEmpleo;
            }
        }

        #endregion




    }
}
