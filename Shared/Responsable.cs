using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaEjemplo.Shared
{
    public class Responsable
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string RFC { get; set; } = string.Empty;
        public int IdAdscripcion { get; set; }
    }
}
