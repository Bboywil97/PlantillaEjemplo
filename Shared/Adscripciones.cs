using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaEjemplo.Shared
{
    public class Adscripciones
    {
        public int Id { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
    public class AdscripcionesService
    {
        public List<Adscripciones> Adscripciones { get; private set; } = new List<Adscripciones>();
        public void AgregarAdscripcion(Adscripciones adscripcion)
        {
            Adscripciones.Add(adscripcion);
        }
    }
}
