using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Demandante
{
    public class DemandanteInscritoOferta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int Edad { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string PerfilLinkedin { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int NivelEstudios { get; set; }
        public string ExperienciaLaboral { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int IdDemandante { get; set; }
        public int IdOfertaEmpleo { get; set; }
        public string Notas { get; set; }
        public string CV { get; set; }
        public int Estado { get; set; }

    }
}
