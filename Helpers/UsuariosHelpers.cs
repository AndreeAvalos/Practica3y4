using Practica3_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica3_4.Helpers
{
    public class UsuariosHelpers
    {
        public static Usuario existeUsuario(string correo, string pass)
        {
            Usuario user = null;
            cargarData.users.ForEach(m =>
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