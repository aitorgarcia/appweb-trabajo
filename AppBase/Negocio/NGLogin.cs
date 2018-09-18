using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Login;
using Core.Usuario;

namespace Negocio
{
    public class NGLogin
    {

        /// <summary>
        /// Comprueba que la validación de los datos sea correcta y llama a UTLogin
        /// para comprobar que exista el usuario con esas credenciales de acceso.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Devuelve el usuario que se ha logueado o null en su defecto</returns>
        public Usuario EsValido(LoginModels usuario)
        {
            //int maxLength = 20;
            //int minLength = 5;

            if(!String.IsNullOrEmpty(usuario.User) && !String.IsNullOrEmpty(usuario.Password)){
                //&& usuario.Password.Length > minLength && usuario.Password.Length < maxLength){

                BaseDeDatos.UTLogin utLogin = new BaseDeDatos.UTLogin();

                Usuario user = utLogin.EsValido(usuario);
                return user;
            }
            return null;
        }
    }
}
