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

        public int IdMarca { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public DateTime? FechaCompra { get; set; } = DateTime.Now;
        public string Estatus { get; set; } = string.Empty;

        public double? PrecioAdquisicion { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.Now;
        
        
        
        public DateTime? FechaAdquisicion { get; set; } = DateTime.Now;
        
        public int? Cantidad { get; set; }
        
    }

    public class ArticulosService
    {
        public List<Articulos> Articulos { get; private set; } = new List<Articulos>();
        public void AgregarInventario(Articulos articulo)
        {
            Articulos.Add(articulo);
        }
    }

}
