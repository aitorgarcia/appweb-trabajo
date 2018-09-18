using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Empleador
{
    public class Empleador
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Es necesario introducir un nombre para la empresa.")]
        public string NombreEmpresa { get; set; }

        public byte[] LogoEmpresa { get; set; }

        [Required(ErrorMessage = "Es necesario introducir una dirección.")]
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


        [Required(ErrorMessage = "Es necesario seleccionar una industria de la lista.")]
        [Range(1, 99999999999, ErrorMessage = "Debes seleccionar una industria de la lista.")]
        public int TipoIndustria { get; set; }

        [Required(ErrorMessage = "Es necesario introducir el número de empleados.")]
        [Range(1,99999999999, ErrorMessage= "Debe existir al menos 1 empleado en la empresa.")]
        public int NumeroEmpleados { get; set; }
    }
}

