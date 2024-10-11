using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Personal
    {
        public int IdPersonal { get; set; }
        public string TipoDoc { get; set; } = string.Empty;
        public string NumeroDoc { get; set; } = string.Empty;
        public string ApPaterno { get; set; } = string.Empty;
        public string ApMaterno { get; set; } = string.Empty;
        public string Nombre1 { get; set; } = string.Empty;
        public string Nombre2 { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public DateTime FechaNac { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
