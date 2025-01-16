using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantillaEjemplo.Shared
{

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
    public class UsuarioService
    {
        public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();

        public void AgregarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }
    }

    

}
