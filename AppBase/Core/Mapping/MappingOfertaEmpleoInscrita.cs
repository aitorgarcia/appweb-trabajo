using Core.Esquemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public static class MappingOfertaEmpleoInscrita
    {

        public static Empleador.OfertaEmpleoInscrita ToOfertaEmpleoInscrita(this dtsOfertaEmpleoInscrita.pInscritosLecturaDataTable dataTable, int row = 0)
        {
            Empleador.OfertaEmpleoInscrita ofertaInscrita = new Empleador.OfertaEmpleoInscrita();
            ofertaInscrita.Id = Convert.ToInt32(dataTable.Rows[row][dataTable.IdColumn.ColumnName]);
            ofertaInscrita.IdEmpleador = Convert.ToInt32(dataTable.Rows[row][dataTable.IdEmpleadorColumn.ColumnName]);
            ofertaInscrita.Descripcion = dataTable.Rows[row][dataTable.DescripcionColumn.ColumnName].ToString();
            ofertaInscrita.NumeroVacantes = Convert.ToInt32(dataTable.Rows[row][dataTable.NumeroVacantesColumn.ColumnName]);
            ofertaInscrita.Sueldo = Convert.ToInt32(dataTable.Rows[row][dataTable.SueldoColumn.ColumnName]);
            ofertaInscrita.FechaLanzamiento = (DateTime)dataTable.Rows[row][dataTable.FechaLanzamientoColumn.ColumnName];
            ofertaInscrita.FechaFin = (DateTime)dataTable.Rows[row][dataTable.FechaFinColumn.ColumnName];
            ofertaInscrita.Observaciones = dataTable.Rows[row][dataTable.ObservacionesColumn.ColumnName].ToString();
            ofertaInscrita.Titulo = dataTable.Rows[row][dataTable.TituloColumn.ColumnName].ToString();

            ofertaInscrita.CV = dataTable.Rows[row][dataTable.CVColumn.ColumnName].ToString();
            ofertaInscrita.Notas = dataTable.Rows[row][dataTable.NotasColumn.ColumnName].ToString();
            ofertaInscrita.Estado = Convert.ToInt32(dataTable.Rows[row][dataTable.EstadoColumn.ColumnName]);
            ofertaInscrita.Nombre = dataTable.Rows[row][dataTable.NombreColumn.ColumnName].ToString();
            ofertaInscrita.NombreEmpresa = dataTable.Rows[row][dataTable.NombreEmpresaColumn.ColumnName].ToString();
            ofertaInscrita.IdDemandante = Convert.ToInt32(dataTable.Rows[row][dataTable.IdDemandanteColumn.ColumnName]);
            ofertaInscrita.IdOfertaEmpleo = Convert.ToInt32(dataTable.Rows[row][dataTable.IdOfertaEmpleoColumn.ColumnName]);



            ofertaInscrita.FechaFinString = ofertaInscrita.FechaFin.ToString();
            ofertaInscrita.FechaFinString = ofertaInscrita.FechaFinString.Substring(0, 10);
            ofertaInscrita.FechaLanzamientoString = ofertaInscrita.FechaLanzamiento.ToString();
            ofertaInscrita.FechaLanzamientoString = ofertaInscrita.FechaLanzamientoString.Substring(0, 10);

            return ofertaInscrita;
        }




        //public static dtsOfertaEmpleoInscrita ToDtsOfertaEmpleoInscrita(this Empleador.OfertaEmpleoInscrita ofertaInscrita)
        //{
        //    dtsOfertaEmpleoInscrita dts = new dtsOfertaEmpleoInscrita();
        //    dtsOfertaEmpleoInscrita.pInscritosLecturaRow dtsRow = dts.pInscritosLectura.NewpInscritosLecturaRow();

        //    dtsRow.IdEmpleador = ofertaInscrita.IdEmpleador;
        //    dtsRow.Descripcion = ofertaInscrita.Descripcion;
        //    dtsRow.NumeroVacantes = ofertaInscrita.NumeroVacantes;
        //    dtsRow.Sueldo = ofertaInscrita.Sueldo;
        //    dtsRow.FechaLanzamiento = DateTime.Now;
        //    dtsRow.FechaFin = (DateTime)ofertaInscrita.FechaFin;
        //    dtsRow.Observaciones = ofertaInscrita.Observaciones;
        //    dtsRow.Titulo = ofertaInscrita.Titulo;

        //    dtsRow.CV = ofertaInscrita.CV;
        //    dtsRow.Notas = ofertaInscrita.Notas;
        //    dtsRow.Estado = (short) ofertaInscrita.Estado;
        //    dtsRow.Nombre = ofertaInscrita.Nombre;
        //    dtsRow.NombreEmpresa = ofertaInscrita.NombreEmpresa;
        //    dtsRow.IdDemandante = ofertaInscrita.IdDemandante;
        //    dtsRow.IdOfertaEmpleo = ofertaInscrita.IdOfertaEmpleo;

        //    dts.pInscritosLectura.AddpInscritosLecturaRow(dtsRow);
        //    return dts;
        //}

    }
}
