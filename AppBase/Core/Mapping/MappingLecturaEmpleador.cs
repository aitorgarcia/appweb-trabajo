using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;

namespace Core.Mapping
{
    public static class MappingLecturaEmpleador
    {


        /// <summary>
        /// Recoge los datos del dataTable introducido por parámetro para agregarselos a un nuevo EmpleadorModel.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="row"></param>
        /// <returns>Devuelve un EmpleadorModel relleno de valores</returns>
        public static Empleador.EmpleadorModel ToEmpleadorModel(this dtsLectura.EmpleadoresDataTable dataTable, int row = 0)
        {
            Empleador.EmpleadorModel empModel = new Empleador.EmpleadorModel();

            empModel.Id = Convert.ToInt32(dataTable.Rows[row][dataTable.IdColumn.ColumnName]);
            empModel.IdUsuario = Convert.ToInt32(dataTable.Rows[row][dataTable.IdUsuarioColumn.ColumnName]);
            empModel.NombreEmpresa = dataTable.Rows[row][dataTable.NombreEmpresaColumn.ColumnName].ToString();
            empModel.LogoEmpresa = (byte[]) dataTable.Rows[row][dataTable.LogoEmpresaColumn.ColumnName];
            empModel.Direccion = dataTable.Rows[row][dataTable.DireccionColumn.ColumnName].ToString();
            empModel.Telefono = dataTable.Rows[row][dataTable.TelefonoColumn.ColumnName].ToString();
            empModel.Email = dataTable.Rows[row][dataTable.EmailColumn.ColumnName].ToString();
            empModel.TipoIndustria = Convert.ToInt16(dataTable.Rows[row][dataTable.TipoIndustriaColumn.ColumnName]);
            empModel.NumeroEmpleados = Convert.ToInt32(dataTable.Rows[row][dataTable.NumeroEmpleadosColumn.ColumnName]);

            empModel.Usuario = dataTable.Rows[row][dataTable.UsuarioColumn.ColumnName].ToString();
            empModel.Nombre = dataTable.Rows[row][dataTable.NombreColumn.ColumnName].ToString();
            empModel.Contrasena = dataTable[row][dataTable.ContrasenaColumn.ColumnName].ToString();
            empModel.Apellido1 = dataTable.Rows[row][dataTable.Apellido1Column.ColumnName].ToString();
            empModel.Apellido2 = dataTable.Rows[row][dataTable.Apellido2Column.ColumnName].ToString();
            empModel.TipoUsuario = Convert.ToInt16(dataTable.Rows[row][dataTable.TipoUsuarioColumn.ColumnName]);
            empModel.TipoIndustriaNombre = dataTable.Rows[row][dataTable.TipoIndustriaNombreColumn.ColumnName].ToString();


            return empModel;
        }






        public static Empleador.EmpleadorModel ToEmpleadorModelVistaAdmin(this dtsLectura.EmpleadoresDataTable dataTable, int row = 0)
        {
            Empleador.EmpleadorModel empModel = new Empleador.EmpleadorModel();

            empModel.Id = Convert.ToInt32(dataTable.Rows[row][dataTable.IdColumn.ColumnName]);
            empModel.IdUsuario = Convert.ToInt32(dataTable.Rows[row][dataTable.IdUsuarioColumn.ColumnName]);
            empModel.NombreEmpresa = dataTable.Rows[row][dataTable.NombreEmpresaColumn.ColumnName].ToString();
            //empModel.LogoEmpresa = (byte[])dataTable.Rows[row][dataTable.LogoEmpresaColumn.ColumnName];
            empModel.Direccion = dataTable.Rows[row][dataTable.DireccionColumn.ColumnName].ToString();
            empModel.Telefono = dataTable.Rows[row][dataTable.TelefonoColumn.ColumnName].ToString();
            empModel.Email = dataTable.Rows[row][dataTable.EmailColumn.ColumnName].ToString();
            empModel.TipoIndustria = Convert.ToInt16(dataTable.Rows[row][dataTable.TipoIndustriaColumn.ColumnName]);
            empModel.NumeroEmpleados = Convert.ToInt32(dataTable.Rows[row][dataTable.NumeroEmpleadosColumn.ColumnName]);

            empModel.Usuario = dataTable.Rows[row][dataTable.UsuarioColumn.ColumnName].ToString();
            empModel.Nombre = dataTable.Rows[row][dataTable.NombreColumn.ColumnName].ToString();
            empModel.Contrasena = dataTable[row][dataTable.ContrasenaColumn.ColumnName].ToString();
            empModel.Apellido1 = dataTable.Rows[row][dataTable.Apellido1Column.ColumnName].ToString();
            empModel.Apellido2 = dataTable.Rows[row][dataTable.Apellido2Column.ColumnName].ToString();
            empModel.TipoUsuario = Convert.ToInt16(dataTable.Rows[row][dataTable.TipoUsuarioColumn.ColumnName]);
            empModel.TipoIndustriaNombre = dataTable.Rows[row][dataTable.TipoIndustriaNombreColumn.ColumnName].ToString();


            return empModel;
        }



    }
}
