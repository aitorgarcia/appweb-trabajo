using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Administracion
{
    public class Administrador
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public DateTime UltimoAcceso { get; set; }
    }
}
