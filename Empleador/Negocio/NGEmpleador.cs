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

namespace Empleador.CapaNegocio
{
    public class NGEmpleador
    {


        /// <summary>
        ///  Realiza una llamada a UTEmpleador para obtener un objeto EmpleadorModel a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto EmpleadorModel</returns>
        public EmpleadorModel GetEmpleadorModelByUserId(int id)
        {
            EmpleadorModel empModel = _UTEmpleador.GetEmpleadorModelByUserId(id);
            empModel.ImagenB64 = Convert.ToBase64String(empModel.LogoEmpresa);

            return empModel;
        }



        /// <summary>
        ///  Comprueba que los datos del Empleador sean válidos y en caso de serlo llama al UTEmpleador para guardar sus datos.
        /// </summary>
        /// <param name="empModel"></param>
        /// <returns>Devuelve un booleano dependiendo de si los datos son válidos, o de la llamada a UTEmpleador.</returns>
        public bool ValidarDatosEmpleador(Core.Empleador.EmpleadorModel empModel)
        {
            if (!String.IsNullOrEmpty(empModel.NombreEmpresa) && !String.IsNullOrEmpty(empModel.Direccion))
            {
                int aux = 0;
                var typeNumEmpleados = empModel.NumeroEmpleados.GetType();
                var typeIdUsuario = empModel.IdUsuario.GetType();
                var typeTipoIndustria = empModel.TipoIndustria.GetType();

                if (empModel.TipoIndustria < 1)
                    empModel.TipoIndustria = 1;

                if (typeNumEmpleados.IsEquivalentTo(aux.GetType()) && typeIdUsuario.IsEquivalentTo(aux.GetType()) && typeTipoIndustria.IsEquivalentTo(aux.GetType()))
                {
                    if (empModel.ImagenB64 == null)
                        empModel.LogoEmpresa = new byte[0];
                    else
                    {
                        empModel.ImagenB64 = empModel.ImagenB64.Replace("data:image/jpeg;base64,", "");
                        empModel.LogoEmpresa = Convert.FromBase64String(empModel.ImagenB64);
                    }

                    return _UTEmpleador.GuardarDatosEmpleador(empModel);
                }

            }
            return false;
        }




        /// <summary>
        ///  Comprueba que los datos del Empleador sean válidos y en caso de serlo llama al UTEmpleador para guardar sus datos.
        /// </summary>
        /// <param name="empModel"></param>
        /// <returns>Devuelve un booleano dependiendo de si los datos son válidos, o de la llamada a UTEmpleador.</returns>
        public bool ValidarDatosModificarEmpleador(Core.Empleador.EmpleadorModel empModel)
        {
            if (!String.IsNullOrEmpty(empModel.NombreEmpresa) && !String.IsNullOrEmpty(empModel.Direccion))
            {
                int aux = 0;
                var typeNumEmpleados = empModel.NumeroEmpleados.GetType();
                var typeIdUsuario = empModel.IdUsuario.GetType();
                var typeTipoIndustria = empModel.TipoIndustria.GetType();

                if (empModel.TipoIndustria < 1)
                    empModel.TipoIndustria = 1;

                if (typeNumEmpleados.IsEquivalentTo(aux.GetType()) && typeIdUsuario.IsEquivalentTo(aux.GetType()) && typeTipoIndustria.IsEquivalentTo(aux.GetType()))
                {
                    if (empModel.ImagenB64 == null)
                        empModel.LogoEmpresa = new byte[0];
                    else
                    {
                        empModel.ImagenB64 = empModel.ImagenB64.Replace("data:image/jpeg;base64,", "");
                        empModel.LogoEmpresa = Convert.FromBase64String(empModel.ImagenB64);
                    }

                    return _UTEmpleador.ModificarDatosEmpleador(empModel);
                }

            }
            return false;
        }



        public bool ValidarDatosModificarUsuario(EmpleadorModel empModel)
        {
            if (!String.IsNullOrEmpty(empModel.NombreEmpresa) && !String.IsNullOrEmpty(empModel.Direccion))
            {
                int aux = 0;
                var typeIdUsuario = empModel.IdUsuario.GetType();

                if (typeIdUsuario.IsEquivalentTo(aux.GetType()))
                {
                    return _UTEmpleador.ModificarDatosUsuario(empModel);
                }

            }
            return false;
        }





        /// <summary>
        ///  Realiza una llamada a UTEmpleador para obtener un objeto Empleador a partir de una id ofrecida por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un objeto Empleador</returns>
        public Core.Empleador.Empleador GetEmpleadorByUserId(int id)
        {
            return _UTEmpleador.GetEmpleadorByUserId(id);
        }



        /// <summary>
        /// Obtiene todos los tipos de industrias realizando una llamada a UTEmpleador.
        /// </summary>
        /// <returns>Una lista de objetos Industria con cada una de ellas.</returns>
        public List<Industria> ObtenerIndustrias()
        {
            List<Industria> result;
            return result = _UTEmpleador.ObtenerIndustrias();
        }





        #region PROPIEDADES
        private UTEmpleador _utEmpleador { get; set; }

        private UTEmpleador _UTEmpleador
        {
            get
            {
                if (_utEmpleador == null)
                {
                    _utEmpleador = new UTEmpleador();
                }
                return _utEmpleador;
            }
        }

        #endregion



    }
}
