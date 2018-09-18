using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Demandante
{
    public class Demandante
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Es necesario introducir tu edad.")]
        [Range(1, 200, ErrorMessage = "La edad introducida debe ser válida")]
        public int Edad { get; set; }

        //[Required(ErrorMessage = "Es necesario introducir una foto para tu perfil.")]
        public byte[] FotoPerfil { get; set; }
        public string PerfilLinkedin { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Es necesario seleccionar un nivel de estudios de la lista.")]
        [Range(0, 99999999999, ErrorMessage = "Debes seleccionar un nivel de estudios.")]
        public int NivelEstudios { get; set; }

        [Required(ErrorMessage = "Debes introducir tu experiencia laboral.")]
        public string ExperienciaLaboral { get; set; }
    }
}
