﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Login;
using GestorBD;
using Core.Usuario;
using Core.Mapping;
using Core.Esquemas;


namespace BaseDeDatos
{
    public class UTLogin : UTBase
    {
        /// <summary>
        /// Comprueba en la base de datos que exista un usuario con dichas credenciales.
        /// </summary>
        /// <param name="lm"></param>
        /// <returns>El usuario completo que se ha logueado o en su defecto el valor null.</returns>
        public Usuario EsValido(LoginModels lm)
        {
            dtsUsuarios dts = MappingUsuario.ToDtsUsuarios(lm);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();

            parametros.Add(dts.Usuarios.UsuarioColumn, lm.User);
            parametros.Add(dts.Usuarios.ContrasenaColumn, lm.Password);

            // Realizamos un merge con al tabla vacia del dtsUsuario con los resultados de la tabla obtenida
            dtsUsuarios.UsuariosDataTable dt = (dtsUsuarios.UsuariosDataTable)Repo.Leer(dts.Usuarios, parametros);

            Usuario user;
            if (dt.Rows.Count > 0)
                user = MappingUsuario.ToUsuario(dt, 0);
            else
                user = null;

            return user;
        }
    }
}