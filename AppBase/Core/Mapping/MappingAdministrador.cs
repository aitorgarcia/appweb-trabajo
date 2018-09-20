using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Administracion;
using Core.Esquemas;

namespace Core.Mapping
{
    public static class MappingAdministrador
    {


        public static Administrador ToAdministrador(this dtsAdministrador.AdministradoresDataTable dataTable, int row = 0)
        {
            Administrador admin = new Administrador();
            admin.Usuario = dataTable.Rows[row][dataTable.UsuarioColumn.ColumnName].ToString();
            admin.Contrasena = dataTable.Rows[row][dataTable.ContrasenaColumn.ColumnName].ToString();
            admin.UltimoAcceso = (DateTime)dataTable.Rows[row][dataTable.UltimoAccesoColumn.ColumnName];

            return admin;
        }




        public static dtsAdministrador ToDtsAdministrador(this Administrador admin)
        {
            dtsAdministrador dts = new dtsAdministrador();
            dtsAdministrador.AdministradoresRow dtsRow = dts.Administradores.NewAdministradoresRow();

            dtsRow.Usuario = admin.Usuario;
            dtsRow.Contrasena = admin.Contrasena;
            dtsRow.UltimoAcceso = (DateTime) admin.UltimoAcceso;

            dts.Administradores.AddAdministradoresRow(dtsRow);
            return dts;
        }

    }
}
