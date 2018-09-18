using Core.Esquemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public static class MappingDemandantesInscritosOferta
    {

        /// <summary>
        /// Recoge los datos del dataTable (dtsDemandantesInscritosOferta) introducido por parámetro para agregarselos a un nuevo DemandanteInscritoOferta.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="row"></param>
        /// <returns>Devuelve un DemandanteInscritoOferta relleno de valores</returns>
        public static Demandante.DemandanteInscritoOferta ToDemandante(this dtsDemandantesInscritosOferta.pDemandantesInscritosOfertaDataTable dataTable, int row = 0)
        {
            Demandante.DemandanteInscritoOferta demInscritoOferta = new Demandante.DemandanteInscritoOferta();
            demInscritoOferta.Id = Convert.ToInt32(dataTable.Rows[row][dataTable.IdColumn.ColumnName]);
            demInscritoOferta.FotoPerfil = (byte[])dataTable.Rows[row][dataTable.FotoPerfilColumn.ColumnName];
            demInscritoOferta.IdUsuario = Convert.ToInt32(dataTable.Rows[row][dataTable.IdUsuarioColumn.ColumnName]);
            demInscritoOferta.Edad = Convert.ToInt32(dataTable.Rows[row][dataTable.EdadColumn.ColumnName]);
            demInscritoOferta.Telefono = dataTable.Rows[row][dataTable.TelefonoColumn.ColumnName].ToString();
            demInscritoOferta.Email = dataTable.Rows[row][dataTable.EmailColumn.ColumnName].ToString();
            demInscritoOferta.PerfilLinkedin = dataTable.Rows[row][dataTable.PerfilLinkedinColumn.ColumnName].ToString();
            demInscritoOferta.ExperienciaLaboral = dataTable.Rows[row][dataTable.ExperienciaLaboralColumn.ColumnName].ToString();
            demInscritoOferta.NivelEstudios = Convert.ToInt32(dataTable.Rows[row][dataTable.NivelEstudiosColumn.ColumnName]);
            demInscritoOferta.Nombre = dataTable.Rows[row][dataTable.NombreColumn.ColumnName].ToString();
            demInscritoOferta.NombreUsuario = dataTable.Rows[row][dataTable.NombreUsuarioColumn.ColumnName].ToString();
            demInscritoOferta.Apellido1 = dataTable.Rows[row][dataTable.Apellido1Column.ColumnName].ToString();
            demInscritoOferta.Apellido2 = dataTable.Rows[row][dataTable.Apellido2Column.ColumnName].ToString();
            demInscritoOferta.IdDemandante = Convert.ToInt32(dataTable.Rows[row][dataTable.IdDemandanteColumn.ColumnName]);
            demInscritoOferta.IdOfertaEmpleo = Convert.ToInt32(dataTable.Rows[row][dataTable.IdOfertaEmpleoColumn.ColumnName]);
            demInscritoOferta.Notas = dataTable.Rows[row][dataTable.NotasColumn.ColumnName].ToString();
            demInscritoOferta.CV = dataTable.Rows[row][dataTable.CVColumn.ColumnName].ToString();
            demInscritoOferta.Estado = Convert.ToInt32(dataTable.Rows[row][dataTable.EstadoColumn.ColumnName]);


            return demInscritoOferta;
        }




        /// <summary>
        /// Recoge los datos del DemandanteInscritoOferta introducido por parámetro para agregarselos a un nuevo dataset de DemandantesInscritos.
        /// </summary>
        /// <param name="demInscritos"></param>
        /// <returns>Devuelve un dataset de DemandantesInscritos relleno de valores.</returns>
        public static dtsDemandantesInscritos ToDtsDemandantesInscritos(this Demandante.DemandanteInscritoOferta demInscritos)
        {
            dtsDemandantesInscritos dts = new dtsDemandantesInscritos();
            dtsDemandantesInscritos.DemandantesInscritosOfertasEmpleoRow dtsRow = dts.DemandantesInscritosOfertasEmpleo.NewDemandantesInscritosOfertasEmpleoRow();

            dtsRow.IdDemandante = demInscritos.IdDemandante;
            dtsRow.IdOfertaEmpleo = demInscritos.IdOfertaEmpleo;
            dtsRow.Notas = demInscritos.Notas;
            dtsRow.CV = demInscritos.CV;
            dtsRow.Estado = 0;

            dts.DemandantesInscritosOfertasEmpleo.AddDemandantesInscritosOfertasEmpleoRow(dtsRow);
            return dts;
        }





        /// <summary>
        /// Recoge los datos del dataTable (dtsDemandantesInscritos) introducido por parámetro para agregarselos a un nuevo DemandanteInscritoOferta.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="row"></param>
        /// <returns>Devuelve un DemandanteInscritoOferta relleno de valores</returns>
        public static Demandante.DemandanteInscritoOferta ToDemandanteInscrito(this dtsDemandantesInscritos.DemandantesInscritosOfertasEmpleoDataTable dataTable, int row = 0)
        {
            Demandante.DemandanteInscritoOferta demInscritoOferta = new Demandante.DemandanteInscritoOferta();
            demInscritoOferta.IdDemandante = Convert.ToInt32(dataTable.Rows[row][dataTable.IdDemandanteColumn.ColumnName]);
            demInscritoOferta.IdOfertaEmpleo = Convert.ToInt32(dataTable.Rows[row][dataTable.IdOfertaEmpleoColumn.ColumnName]);
            demInscritoOferta.Notas = dataTable.Rows[row][dataTable.NotasColumn.ColumnName].ToString();
            demInscritoOferta.CV = dataTable.Rows[row][dataTable.CVColumn.ColumnName].ToString();
            demInscritoOferta.Estado = Convert.ToInt32(dataTable.Rows[row][dataTable.EstadoColumn.ColumnName]);

            return demInscritoOferta;
        }


    }
}
