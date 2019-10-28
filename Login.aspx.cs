using Practica3_4.Helpers;
using Practica3_4.Models;
using System;

namespace Practica3_4
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;  
        }

        protected void IniciarSesion(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombreUsuario.Text))
            {
                divError.InnerText = "El usuario esta vacio!.";
                divError.Visible = true;
                return;
            }
            else if (string.IsNullOrEmpty(password.Text))
            {
                divError.InnerText = "La contraseña esta vacia!.";
                divError.Visible = true;
                return;
            }
            Usuario usuarioExistente = UsuariosHelpers.existeUsuario(nombreUsuario.Text, password.Text);
            if (usuarioExistente != null)
            {
                Session["usuarioActual"] = usuarioExistente;
                divError.Visible = false;
                Response.Redirect("PerfilUsuario.aspx?parametro=" + nombreUsuario.Text);
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                divError.InnerText = "No se ha podido iniciar sesión, los datos no son validos.";
                divError.Visible = true;
            }
        }
    }
}