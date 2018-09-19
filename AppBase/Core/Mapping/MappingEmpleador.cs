using Core.Esquemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public static class MappingEmpleador
    {
        /// <summary>
        ///  Recoge los datos del dataTable introducido por parámetro para agregarselos a un nuevo Empleador.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="row"></param>
        /// <returns>Devuelve un Empleador relleno de valores</returns>
        public static Empleador.Empleador ToEmpleador(this dtsEmpleadores.EmpleadoresDataTable dataTable, int row = 0)
        {
            Empleador.Empleador emp = new Empleador.Empleador();
            emp.Id = Convert.ToInt32(dataTable.Rows[row][dataTable.IdColumn.ColumnName]);
            emp.IdUsuario = Convert.ToInt32(dataTable.Rows[row][dataTable.IdUsuarioColumn.ColumnName]);
            emp.NombreEmpresa = dataTable.Rows[row][dataTable.NombreEmpresaColumn.ColumnName].ToString();
            emp.Direccion = dataTable.Rows[row][dataTable.DireccionColumn.ColumnName].ToString();
            emp.Telefono = dataTable.Rows[row][dataTable.TelefonoColumn.ColumnName].ToString();
            emp.Email = dataTable.Rows[row][dataTable.EmailColumn.ColumnName].ToString();
            emp.TipoIndustria = Convert.ToInt32(dataTable.Rows[row][dataTable.TipoIndustriaColumn.ColumnName]);
            emp.NumeroEmpleados = Convert.ToInt32(dataTable.Rows[row][dataTable.NumeroEmpleadosColumn.ColumnName]);

            return emp;
        }



        /// <summary>
        /// Recoge los datos del Empleador introducido por parámetro para agregarselos a un nuevo dataset de Empleador.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>Devuelve un dataset de Empleadores relleno de valores.</returns>
        public static dtsEmpleadores ToDtsEmpleadores(this Empleador.Empleador emp)
        {
            dtsEmpleadores dts = new dtsEmpleadores();
            dtsEmpleadores.EmpleadoresRow dtsRow = dts.Empleadores.NewEmpleadoresRow();

            dtsRow.IdUsuario = emp.IdUsuario;
            dtsRow.NombreEmpresa = emp.NombreEmpresa;
            dtsRow.Direccion = emp.Direccion;
            dtsRow.Telefono = emp.Telefono;
            dtsRow.Email = emp.Email;
            dtsRow.NumeroEmpleados = emp.NumeroEmpleados;
            dtsRow.LogoEmpresa = emp.LogoEmpresa;
            dtsRow.TipoIndustria = (short)emp.TipoIndustria;
            
            dts.Empleadores.AddEmpleadoresRow(dtsRow);
            return dts;
        }



        /// <summary>
        /// Recoge los datos del Empleador introducido por parámetro para agregarselos a un nuevo dataset de Empleador.
        /// </summary>
        /// <param name="empModel"></param>
        /// <returns>Devuelve un dataset de Empleadores relleno de valores.</returns>
        public static dtsEmpleadores ToDtsEmpleadoresModificar(this Empleador.EmpleadorModel empModel)
        {
            dtsEmpleadores dts = new dtsEmpleadores();
            dtsEmpleadores.EmpleadoresRow dtsRow = dts.Empleadores.NewEmpleadoresRow();
            
            dtsRow.Id = empModel.Id;
            dtsRow.IdUsuario = empModel.IdUsuario;
            dtsRow.NombreEmpresa = empModel.NombreEmpresa;
            dtsRow.Direccion = empModel.Direccion;
            dtsRow.Telefono = empModel.Telefono;
            dtsRow.Email = empModel.Email;
            dtsRow.NumeroEmpleados = empModel.NumeroEmpleados;
            dtsRow.LogoEmpresa = empModel.LogoEmpresa;
            dtsRow.TipoIndustria = (short)empModel.TipoIndustria;

            dts.Empleadores.AddEmpleadoresRow(dtsRow);
            dts.Empleadores.AcceptChanges();
            dts.Empleadores[0].SetModified();
            return dts;
        }




        public static dtsUsuarios ToDtsUsuarioModificar(this Empleador.EmpleadorModel empModel)
        {
            dtsUsuarios dts = new dtsUsuarios();
            dtsUsuarios.UsuariosRow dtsRow = dts.Usuarios.NewUsuariosRow();

            dtsRow.Id = empModel.IdUsuario;
            dtsRow.Usuario = empModel.Usuario;
            dtsRow.Nombre = empModel.Nombre;
            dtsRow.Apellido1 = empModel.Apellido1;
            dtsRow.Apellido2 = empModel.Apellido2;
            dtsRow.Contrasena = empModel.Contrasena;
            dtsRow.TipoUsuario = (short)empModel.TipoUsuario;

            dts.Usuarios.AddUsuariosRow(dtsRow);
            dts.Usuarios.AcceptChanges();
            dts.Usuarios[0].SetModified();
            return dts;
        }
    }
}
