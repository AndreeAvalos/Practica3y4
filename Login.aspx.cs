using Newtonsoft.Json;
using Practica3_4.Helpers;
using Practica3_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                divError.InnerText = "No se ha podido iniciar sesión, los datos no son validos.";
                divError.Visible = true;
            }
        }

        protected void RegistrarUsuario(object sender, EventArgs e)
        {
            Usuario _data = new Usuario();
            _data.Dpi = 3000000000000;
            _data.Nombre = "nath";
            _data.Apellido = "c";
            _data.Correo = "correo";
            _data.Cuenta = 206000;
            _data.Saldo = 1000;
            _data.Password = "12345";
            cargarData.users.Add(_data);
            string json = JsonConvert.SerializeObject(cargarData.users);
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\database\usuarios.json", json);
        }
    }
}