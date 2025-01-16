using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaEjemplo.Shared
{
    public class Articulos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public string Marca { get; set; } = string.Empty;
        public DateTime? FechaRegistro { get; set; } = DateTime.Now;
        
        public string Estatus { get; set; } = string.Empty;
        public DateTime? FechaCompra { get; set; } = DateTime.Now;
        public DateTime? FechaAdquisicion { get; set; } = DateTime.Now;
        public double? PrecioAdquisicion { get; set; }
        public string Producto { get; set; } = string.Empty;
        public int? Cantidad { get; set; }
        public string Caracteristicas { get; set; } = string.Empty;
    }
}
