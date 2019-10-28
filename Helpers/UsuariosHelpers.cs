using Practica3_4.Models;
using System;
namespace Practica3_4.Helpers
{
    public static class UsuariosHelpers
    {
        public static Usuario existeUsuario(string correo, string pass)
        {
            Usuario user = null;
            CargarData.Users.ForEach(m =>
            {
                if (m.Correo.Equals(correo, StringComparison.InvariantCultureIgnoreCase)
                && m.Password.Equals(pass))
                {
                    user = m;
                }
            });
            return user;
        }
    }
}