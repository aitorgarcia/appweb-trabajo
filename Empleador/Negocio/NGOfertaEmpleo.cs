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
            UTOfertaEmpleo utOfertaEmpleo = new UTOfertaEmpleo();
            bool result = utOfertaEmpleo.GuardarDatosOfertaEmpleo(oferta);
            return result;
        }




        public bool CambiarEstado(Core.Demandante.DemandanteInscritoOferta demInscrito)
        {
            UTOfertaEmpleo utOfertaEmpleo = new UTOfertaEmpleo();
            int idOferta = demInscrito.IdOfertaEmpleo;
            int estado = demInscrito.Estado;
            int idDemandante = demInscrito.IdDemandante;

            bool result = utOfertaEmpleo.CambiarEstado(idOferta, idDemandante, estado);
            return result;
        }











        /// <summary>
        /// Obtiene todos los tipos de industrias realizando una llamada a UTEmpleador.
        /// </summary>
        /// <returns>Una lista de objetos Industria con cada una de ellas.</returns>
        public List<OfertaEmpleo> ObtenerOfertas(int idEmpleador)
        {   
            UTOfertaEmpleo utOfertaEmpleo = new UTOfertaEmpleo();
            List<OfertaEmpleo> result;
            return result = utOfertaEmpleo.GetOfertasByIdEmpleador(idEmpleador);
        }


        public List<DemandanteInscritoOferta> GetDemandantesInscritosOferta(int idOferta)
        {
            UTOfertaEmpleo utOfertaEmpleo = new UTOfertaEmpleo();
            List<DemandanteInscritoOferta> result;
            return result = utOfertaEmpleo.GetDemandantesInscritosOferta(idOferta);
        }

    }
}
