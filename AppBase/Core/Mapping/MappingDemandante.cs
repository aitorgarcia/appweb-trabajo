using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;

namespace Core.Mapping
{
    public static class MappingDemandante
    {

        /// <summary>
        /// Método que crea un nuevo Demandante que lo devuelve con los valores del DataTable introducido por parámetro. 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="row"></param>
        /// <returns>Devuelve un Demandante relleno de valores</returns>
        public static Demandante.Demandante ToDemandante(this dtsDemandantes.DemandantesDataTable dataTable, int row = 0)
        {
            Demandante.Demandante dem = new Demandante.Demandante();
            dem.Id = Convert.ToInt32(dataTable.Rows[row][dataTable.IdColumn.ColumnName]);
            dem.FotoPerfil = (byte[]) dataTable.Rows[row][dataTable.FotoPerfilColumn.ColumnName];
            dem.IdUsuario = Convert.ToInt32(dataTable.Rows[row][dataTable.IdUsuarioColumn.ColumnName]);
            dem.Edad = Convert.ToInt32(dataTable.Rows[row][dataTable.EdadColumn.ColumnName]);
            dem.Telefono = dataTable.Rows[row][dataTable.TelefonoColumn.ColumnName].ToString();
            dem.Email = dataTable.Rows[row][dataTable.EmailColumn.ColumnName].ToString();
            dem.PerfilLinkedin = dataTable.Rows[row][dataTable.PerfilLinkedinColumn.ColumnName].ToString();
            dem.ExperienciaLaboral = dataTable.Rows[row][dataTable.ExperienciaLaboralColumn.ColumnName].ToString();
            dem.NivelEstudios = Convert.ToInt32(dataTable.Rows[row][dataTable.NivelEstudiosColumn.ColumnName]);

            return dem;
        }



        /// <summary>
        /// Método que devuelve un dtsDemandantes con los valores de un Demandante introducido por parámetro.
        /// </summary>
        /// <param name="dem"></param>
        /// <returns>Devuelve un dataset de Demandantes relleno de valores.</returns>
        public static dtsDemandantes ToDtsDemandantes(this Demandante.Demandante dem)
        {
            dtsDemandantes dts = new dtsDemandantes();
            dtsDemandantes.DemandantesRow dtsRow = dts.Demandantes.NewDemandantesRow();

            dtsRow.IdUsuario = dem.IdUsuario;
            dtsRow.FotoPerfil = dem.FotoPerfil;
            dtsRow.Edad = (short)dem.Edad;
            dtsRow.Telefono = dem.Telefono;
            dtsRow.Email = dem.Email;
            dtsRow.PerfilLinkedin = dem.PerfilLinkedin;
            dtsRow.ExperienciaLaboral = dem.ExperienciaLaboral;
            dtsRow.NivelEstudios = (short)dem.NivelEstudios;


            dts.Demandantes.AddDemandantesRow(dtsRow);
            return dts;
        }




        /// <summary>
        /// Método que devuelve un dtsDemandantes con los valores de un Demandante introducido por parámetro.
        /// </summary>
        /// <param name="demModel"></param>
        /// <returns>Devuelve un dataset de Demandantes relleno de valores.</returns>
        public static dtsDemandantes ToDtsDemandantesModificar(this Demandante.DemandanteModel demModel)
        {
            dtsDemandantes dts = new dtsDemandantes();
            dtsDemandantes.DemandantesRow dtsRow = dts.Demandantes.NewDemandantesRow();

            dtsRow.Id = demModel.Id;
            dtsRow.IdUsuario = demModel.IdUsuario;
            dtsRow.FotoPerfil = demModel.FotoPerfil;
            dtsRow.Edad = (short)demModel.Edad;
            dtsRow.Telefono = demModel.Telefono;
            dtsRow.Email = demModel.Email;
            dtsRow.PerfilLinkedin = demModel.PerfilLinkedin;
            dtsRow.ExperienciaLaboral = demModel.ExperienciaLaboral;
            dtsRow.NivelEstudios = (short)demModel.NivelEstudios;

            dts.Demandantes.AddDemandantesRow(dtsRow);
            dts.Demandantes.AcceptChanges();
            dts.Demandantes[0].SetModified();
            return dts;
        }




        public static dtsUsuarios ToDtsUsuarioModificar(this Demandante.DemandanteModel demModel)
        {
            dtsUsuarios dts = new dtsUsuarios();
            dtsUsuarios.UsuariosRow dtsRow = dts.Usuarios.NewUsuariosRow();

            dtsRow.Id = demModel.IdUsuario;
            dtsRow.Usuario = demModel.Usuario;
            dtsRow.Nombre = demModel.Nombre;
            dtsRow.Apellido1 = demModel.Apellido1;
            dtsRow.Apellido2 = demModel.Apellido2;
            dtsRow.Contrasena = demModel.Contrasena;
            dtsRow.TipoUsuario = (short)demModel.TipoUsuario;

            dts.Usuarios.AddUsuariosRow(dtsRow);
            dts.Usuarios.AcceptChanges();
            dts.Usuarios[0].SetModified();
            return dts;
        }
    }
}
