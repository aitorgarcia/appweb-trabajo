using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;
using System.Data;

namespace Core.Mapping
{
    public static class MappingOfertaEmpleo
    {

        /// <summary>
        ///  Recoge los datos del dataTable introducido por parámetro para agregarselos a una nueva OfertaEmpleo.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="row"></param>
        /// <returns>Devuelve una OfertaEmpleo rellena de valores</returns>
        public static Empleador.OfertaEmpleo ToOfertaEmpleo(this dtsOfertaEmpleo.OfertasEmpleoDataTable dataTable, int row = 0)
        {
            Empleador.OfertaEmpleo oferta = new Empleador.OfertaEmpleo();
            oferta.Id = Convert.ToInt32(dataTable.Rows[row][dataTable.IdColumn.ColumnName]);
            oferta.IdEmpleador = Convert.ToInt32(dataTable.Rows[row][dataTable.IdEmpleadorColumn.ColumnName]);
            oferta.Descripcion = dataTable.Rows[row][dataTable.DescripcionColumn.ColumnName].ToString();
            oferta.NumeroVacantes = Convert.ToInt32(dataTable.Rows[row][dataTable.NumeroVacantesColumn.ColumnName]);
            oferta.Sueldo = Convert.ToInt32(dataTable.Rows[row][dataTable.SueldoColumn.ColumnName]);
            oferta.FechaLanzamiento = (DateTime) dataTable.Rows[row][dataTable.FechaLanzamientoColumn.ColumnName];
            oferta.FechaFin = (DateTime) dataTable.Rows[row][dataTable.FechaFinColumn.ColumnName];
            oferta.Observaciones = dataTable.Rows[row][dataTable.ObservacionesColumn.ColumnName].ToString();
            oferta.Titulo = dataTable.Rows[row][dataTable.TituloColumn.ColumnName].ToString();

            oferta.FechaFinString = oferta.FechaFin.ToString();
            oferta.FechaFinString = oferta.FechaFinString.Substring(0, 10);
            oferta.FechaLanzamientoString = oferta.FechaLanzamiento.ToString();
            oferta.FechaLanzamientoString = oferta.FechaLanzamientoString.Substring(0, 10);


            return oferta;
        }



        /// <summary>
        /// Recoge los datos de la OfertaEmpleo introducida por parámetro para agregarselos a un nuevo dataset de Ofertas.
        /// </summary>
        /// <param name="oferta"></param>
        /// <returns>Devuelve un dataset de OfertaEmpleo relleno de valores.</returns>
        public static dtsOfertaEmpleo ToDtsOfertaEmpleo(this Empleador.OfertaEmpleo oferta)
        {
            dtsOfertaEmpleo dts = new dtsOfertaEmpleo();
            dtsOfertaEmpleo.OfertasEmpleoRow dtsRow = dts.OfertasEmpleo.NewOfertasEmpleoRow();

            dtsRow.IdEmpleador = oferta.IdEmpleador;
            dtsRow.Descripcion = oferta.Descripcion;
            dtsRow.NumeroVacantes = oferta.NumeroVacantes;
            dtsRow.Sueldo = oferta.Sueldo;
            dtsRow.FechaLanzamiento = DateTime.Now;
            dtsRow.FechaFin = (DateTime) oferta.FechaFin;
            dtsRow.Observaciones = oferta.Observaciones;
            dtsRow.Titulo = oferta.Titulo;


            dts.OfertasEmpleo.AddOfertasEmpleoRow(dtsRow);
            return dts;
        }

    }
}
