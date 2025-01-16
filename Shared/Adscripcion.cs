using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaEjemplo.Shared
{
    public class Adscripcion
    {
        public int Id { get; set; }
        public string Clave { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }

    public class AdscripcionService
    {
        public List<Adscripcion> Adscripciones { get; private set; } = new List<Adscripcion>();

        public void AgregarAdscripcion(Adscripcion adscripcion)
        {
            Adscripciones.Add(adscripcion);
        }

        public void EliminarAdscripcion(Adscripcion adscripcion)
        {
            Adscripciones.Remove(adscripcion);
        }

        public void ActualizarAdscripcion(Adscripcion adscripcion)
        {
            var index = Adscripciones.FindIndex(a => a.Id == adscripcion.Id);
            if (index != -1)
            {
                Adscripciones[index] = adscripcion;
            }
        }

        public void OrdenarAdscripciones()
        {
            Adscripciones = Adscripciones.OrderBy(x => x.Id).ToList();
        }
    }
}


