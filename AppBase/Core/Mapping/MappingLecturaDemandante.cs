using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;

namespace Core.Mapping
{
    public static class MappingLecturaDemandante
    {

        /// <summary>
        /// Recoge los datos del dataTable introducido por parámetro para agregarselos a un nuevo DemandanteModel.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="row"></param>
        /// <returns>Devuelve un DemandanteModel relleno de valores</returns>
        public static Demandante.DemandanteModel ToDemandanteModel(this dtsLecturaDemandantes.DemandantesDataTable dataTable, int row = 0)
        {
            Demandante.DemandanteModel demModel = new Demandante.DemandanteModel();

            demModel.Id = Convert.ToInt32(dataTable.Rows[row][dataTable.IdColumn.ColumnName]);
            demModel.FotoPerfil = (byte[]) dataTable.Rows[row][dataTable.FotoPerfilColumn.ColumnName];
            demModel.IdUsuario = Convert.ToInt32(dataTable.Rows[row][dataTable.IdUsuarioColumn.ColumnName]);
            demModel.Edad = Convert.ToInt32(dataTable.Rows[row][dataTable.EdadColumn.ColumnName]);
            demModel.Telefono = dataTable.Rows[row][dataTable.TelefonoColumn.ColumnName].ToString();
            demModel.Email = dataTable.Rows[row][dataTable.EmailColumn.ColumnName].ToString();
            demModel.PerfilLinkedin = dataTable.Rows[row][dataTable.PerfilLinkedinColumn.ColumnName].ToString();
            demModel.ExperienciaLaboral = dataTable.Rows[row][dataTable.ExperienciaLaboralColumn.ColumnName].ToString();
            demModel.NivelEstudios = Convert.ToInt32(dataTable.Rows[row][dataTable.NivelEstudiosColumn.ColumnName]);

            demModel.Usuario = dataTable.Rows[row][dataTable.UsuarioColumn.ColumnName].ToString();
            demModel.Contrasena = dataTable[row][dataTable.ContrasenaColumn.ColumnName].ToString();
            demModel.Nombre = dataTable.Rows[row][dataTable.NombreColumn.ColumnName].ToString();
            demModel.Apellido1 = dataTable.Rows[row][dataTable.Apellido1Column.ColumnName].ToString();
            demModel.Apellido2 = dataTable.Rows[row][dataTable.Apellido2Column.ColumnName].ToString();
            demModel.TipoUsuario = Convert.ToInt16(dataTable.Rows[row][dataTable.TipoUsuarioColumn.ColumnName]);
            demModel.NivelEstudiosNombre = dataTable.Rows[row][dataTable.NivelEstudiosNombreColumn.ColumnName].ToString();


            return demModel;
        }





        public static Demandante.DemandanteModel ToDemandanteModelVistaAdmin(this dtsLecturaDemandantes.DemandantesDataTable dataTable, int row = 0)
        {
            Demandante.DemandanteModel demModel = new Demandante.DemandanteModel();

            demModel.Id = Convert.ToInt32(dataTable.Rows[row][dataTable.IdColumn.ColumnName]);
            //demModel.FotoPerfil = (byte[])dataTable.Rows[row][dataTable.FotoPerfilColumn.ColumnName];
            demModel.IdUsuario = Convert.ToInt32(dataTable.Rows[row][dataTable.IdUsuarioColumn.ColumnName]);
            demModel.Edad = Convert.ToInt32(dataTable.Rows[row][dataTable.EdadColumn.ColumnName]);
            demModel.Telefono = dataTable.Rows[row][dataTable.TelefonoColumn.ColumnName].ToString();
            demModel.Email = dataTable.Rows[row][dataTable.EmailColumn.ColumnName].ToString();
            demModel.PerfilLinkedin = dataTable.Rows[row][dataTable.PerfilLinkedinColumn.ColumnName].ToString();
            demModel.ExperienciaLaboral = dataTable.Rows[row][dataTable.ExperienciaLaboralColumn.ColumnName].ToString();
            demModel.NivelEstudios = Convert.ToInt32(dataTable.Rows[row][dataTable.NivelEstudiosColumn.ColumnName]);

            demModel.Usuario = dataTable.Rows[row][dataTable.UsuarioColumn.ColumnName].ToString();
            demModel.Contrasena = dataTable[row][dataTable.ContrasenaColumn.ColumnName].ToString();
            demModel.Nombre = dataTable.Rows[row][dataTable.NombreColumn.ColumnName].ToString();
            demModel.Apellido1 = dataTable.Rows[row][dataTable.Apellido1Column.ColumnName].ToString();
            demModel.Apellido2 = dataTable.Rows[row][dataTable.Apellido2Column.ColumnName].ToString();
            demModel.TipoUsuario = Convert.ToInt16(dataTable.Rows[row][dataTable.TipoUsuarioColumn.ColumnName]);
            demModel.NivelEstudiosNombre = dataTable.Rows[row][dataTable.NivelEstudiosNombreColumn.ColumnName].ToString();


            return demModel;
        }


    }
}
