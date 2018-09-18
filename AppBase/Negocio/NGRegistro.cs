using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Registro;

namespace Negocio
{
    public class NGRegistro
    {

        /// <summary>
        /// Comprueba que los datos del formulario superen la validación de la capa de negocios
        /// y de ser así, llama al UTRegistro para comprobar si se puede registrar y en caso afirmativo registrarlo.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Un valor booleano según si se ha registrado o no.</returns>
        public bool EsRegistrable(RegistroModels usuario)
        {
            int maxLength = 20;
            int minLength = 5;

            bool tipoUsuarioCorrecto;
            if (usuario.TipoUsuario == 1 || usuario.TipoUsuario == 0)
                tipoUsuarioCorrecto = true;
            else
                tipoUsuarioCorrecto = false;


            if (!String.IsNullOrEmpty(usuario.User) && !String.IsNullOrEmpty(usuario.Password) && !String.IsNullOrEmpty(usuario.Nombre)
                && !String.IsNullOrEmpty(usuario.Apellido1) && !String.IsNullOrEmpty(usuario.Apellido2)
                && tipoUsuarioCorrecto && usuario.Password.Length > minLength && usuario.Password.Length < maxLength)
            {
                BaseDeDatos.UTRegistro utRegistro = new BaseDeDatos.UTRegistro();


                if (utRegistro.EsRegistrable(usuario))
                    return utRegistro.Registrar(usuario);
            }

            return false;
        }

    }
}
