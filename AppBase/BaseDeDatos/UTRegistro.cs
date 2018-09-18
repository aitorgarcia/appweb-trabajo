using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorBD;
using Core.Registro;
using Core.Esquemas;
using Core.Mapping;

namespace BaseDeDatos
{
    public class UTRegistro : UTBase
    {
        /// <summary>
        /// Registra los datos del Usuario obtenido en la base de datos.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Un valor booleano según si se ha añadido correctamente o no.</returns>
        public bool Registrar(RegistroModels usuario)
        {
            dtsUsuarios dts = MappingUsuario.ToDtsUsuarios(usuario);
            Repo.Guardar(dts);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Usuarios.UsuarioColumn, usuario.User);

            return Repo.Count(dts.Usuarios, parametros) == 1;
        }




        /// <summary>
        /// Comprueba en la base de datos que el usuario no exista ya para poder registrarlo.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Devuelve un valor booleano según si está ya registrado o no. (false = ya está registrado)</returns>
        public bool EsRegistrable(RegistroModels usuario)
        {
            dtsUsuarios dts = MappingUsuario.ToDtsUsuarios(usuario);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Usuarios.UsuarioColumn, usuario.User);

            return Repo.Count(dts.Usuarios, parametros) == 0;
        }

    }
}
