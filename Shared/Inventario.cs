using PlantillaEjemplo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace PlantillaEjemplo.Shared
{
    public class Inventario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public DateTime? FechaRegistro { get; set; } = DateTime.Now;

        public string Marca { get; set; } = string.Empty;

        public string Estatus { get; set; } = string.Empty;

        public DateTime? FechaCompra { get; set; } = DateTime.Now;
        public DateTime? FechaAdquisicion { get; set; } = DateTime.Now;

        public double? PrecioAdquisicion { get; set; }

        public string Producto { get; set; } = string.Empty;

        public int? Cantidad { get; set; }

        public string Caracteristicas { get; set; } = string.Empty;
    }
}
public class UsuarioService
{
    public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();

    public void AgregarUsuario(Usuario usuario)
    {
        Usuarios.Add(usuario);
    }
}

public class Usuario
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string RFC { get; set; } = string.Empty;

    public bool IsEditing { get; set; } = false;

    public string PasswordMasked => new string('*', Password.Length);
}