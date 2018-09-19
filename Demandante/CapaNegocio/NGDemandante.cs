using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Login;
using Core.Usuario;
using Core.Demandante;
using Core.Estudio;
using DemandanteAccesoDatos;

namespace CapaNegocio
{
    public class NGDemandante
    {


        /// <summary>
        ///  Realiza una llamada a UTDemandante para obtener un objeto DemandanteModel a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto DemandanteModel</returns>
        public DemandanteModel GetDemandanteModelByUserId(int id)
        {
            DemandanteModel demModel = _UTDemandante.GetDemandanteModelByUserId(id);
            demModel.ImagenB64 = Convert.ToBase64String(demModel.FotoPerfil);

            return demModel;
        }



        /// <summary>
        ///  Realiza una llamada a UTDemandante para obtener un objeto Demandante a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto Demandante</returns>
        public Demandante GetDemandanteByUserId(int id)
        {
            return _UTDemandante.GetDemandanteByUserId(id);
        }



        /// <summary>
        ///  Comprueba que los datos del Demandante sean válidos y en caso de serlo llama al UTDemandante para guardar sus datos.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>Devuelve un booleano dependiendo de si los datos son válidos, o de la llamada a UTDemandante.</returns>
        public bool ValidarDatosDemandante(DemandanteModel demModel)
        {

            if (!String.IsNullOrEmpty(demModel.ExperienciaLaboral) && !String.IsNullOrEmpty(demModel.ImagenB64))
            {
                int aux = 0;
                var typeEdad = demModel.Edad.GetType();
                var typeIdUsuario = demModel.IdUsuario.GetType();
                var typeNivelEstudios = demModel.NivelEstudios.GetType();

                if (typeEdad.IsEquivalentTo(aux.GetType()) && typeIdUsuario.IsEquivalentTo(aux.GetType()) && typeNivelEstudios.IsEquivalentTo(aux.GetType()))
                {
                    if (demModel.ImagenB64 == null)
                        demModel.FotoPerfil = new byte[0];
                    else
                    {
                        demModel.ImagenB64 = demModel.ImagenB64.Replace("data:image/jpeg;base64,", "");
                        demModel.FotoPerfil = Convert.FromBase64String(demModel.ImagenB64);
                    }

                    return _UTDemandante.GuardarDatosDemandante(demModel);
                }

            }
            return false;
        }






        public bool ValidarDatosModificarDemandante(DemandanteModel demModel)
        {
            if (demModel.ImagenB64 == null)
                demModel.FotoPerfil = new byte[0];
            else
            {
                demModel.ImagenB64 = demModel.ImagenB64.Replace("data:image/jpeg;base64,", "");
                demModel.FotoPerfil = Convert.FromBase64String(demModel.ImagenB64);
            }

            return _UTDemandante.ModificarDatosDemandante(demModel);
        }



        public bool ValidarDatosModificarUsuario(DemandanteModel demModel)
        {
            return _UTDemandante.ModificarDatosUsuario(demModel);
        }








        /// <summary>
        /// Obtiene todos los niveles de estudios realizando una llamada a UTDemandante.
        /// </summary>
        /// <returns>Una lista de objetos Estudio con cada una de los niveles.</returns>
        public List<Estudio> ObtenerEstudios()
        {
            List<Estudio> result;
            return result = _UTDemandante.ObtenerEstudios();
        }






        #region PROPIEDADES
        private UTDemandante _utDemandante { get; set; }


        private UTDemandante _UTDemandante
        {
            get
            {
                if (_utDemandante == null)
                {
                    _utDemandante = new UTDemandante();
                }
                return _utDemandante;
            }

            set { }
        }
        #endregion



    }
}
