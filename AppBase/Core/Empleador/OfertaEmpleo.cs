using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Empleador
{
    public class OfertaEmpleo
    {
        public int Id { get; set; }
        public int IdEmpleador { get; set; }

        [Required(ErrorMessage = "Es necesario introducir una descripción.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Es necesario introducir el número de vacantes.")]
        public int NumeroVacantes { get; set; }
        public int Sueldo { get; set; }

        [Required(ErrorMessage = "Es necesario introducir una fecha de comienzo.")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "Es necesario introducir una fecha de fin.")]
        public DateTime FechaFin { get; set; }
        public string Observaciones { get; set; }
        public string Titulo { get; set; }
        public string FechaLanzamientoString { get; set; }
        public string FechaFinString { get; set; }
    }
}
