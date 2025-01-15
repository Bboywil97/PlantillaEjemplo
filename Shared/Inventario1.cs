using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaEjemplo.Shared
{
    public class Inventario1
    {
        public int Id { get; set; }
        public DateTime FechaCaptura { get; set; } = DateTime.Now;
        public int IdUsuarioCaptura { get; set; }
        public int IdResponsable { get; set; }
        public int IdArticulo { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public DateTime FechaAsignacion { get; set; } = DateTime.Now;
    }
}
