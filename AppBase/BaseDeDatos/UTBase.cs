using GestorBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{
    public class UTBase
    {
        /// <summary>
        /// Constructor de la clase.
        /// Crea una nueva conexión con la cadena de las propiedades
        /// y inicia un nuevo repositorio con dicha conexión.
        /// </summary>
        public UTBase()
        {
            //Se crea la conexión con la cadena anterior.
            SqlConnection connection = new SqlConnection(StringConnection);
            Repo = new Repositorio(connection);
        }




        #region PROPIEDADES
        private string StringConnection = "Data Source=PRODUCCION;Initial Catalog=Prueba;Persist Security Info=True;User ID=sa;Password=Nivelsql*55";
        public Repositorio Repo;
        #endregion
    }
}
