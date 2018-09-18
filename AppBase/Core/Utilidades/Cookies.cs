using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Utilidades
{
    public class Cookies
    {
        /// <summary>
        /// Crea una nueva cookie cuyo nombre es el parámetro 'name' y su valor 'value'.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void AddCookie(string name, string value)
        {
            if (System.Web.HttpContext.Current.Response.Cookies[cookieName] == null)
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Expires = DateTime.Now.AddDays(1);

                if (value == null)
                    cookie.Values[name] = null;
                else
                    cookie.Values[name] = value;
            }
            else
            {
                if (value == null)
                    System.Web.HttpContext.Current.Response.Cookies[cookieName][name] = null;
                else
                    System.Web.HttpContext.Current.Response.Cookies[cookieName][name] = value;
            }
        }



        /// <summary>
        /// Obtiene la cookie cuyo nombre coincide con el parámetro 'name'.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Devuelve la cookie correspondiente.</returns>
        public static string GetCookie(string name)
        {
            return System.Web.HttpContext.Current.Request.Cookies[cookieName][name];
        }



        #region PROPIEDADES
        private static string cookieName = "AppBase";
        public const String Usuario = "Usuario";
        #endregion
    }
}