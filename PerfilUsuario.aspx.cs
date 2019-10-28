using Newtonsoft.Json;
using Practica3_4.Models;
using System;
using System.IO;

namespace Practica3_4
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = Request.Params["parametro"];
            if (string.IsNullOrEmpty(usuario)) {
                Response.Redirect("Login.aspx");
                return;
            }
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\database\usuarios.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var usuarios = JsonConvert.DeserializeObject<Usuario[]>(json);
                foreach (var datos in usuarios)
                {
                    if (usuario.Equals(datos.Correo.ToString()))
                    {
                        lbldpi.Text = datos.Dpi.ToString();
                        lblnombre.Text = datos.Nombre.ToString();
                        lblapellido.Text = datos.Apellido.ToString();
                        lblcuenta.Text = datos.Cuenta.ToString();
                        lblsaldo.Text = datos.Cuenta.ToString();
                        lblcorreo.Text = datos.Correo.ToString();
                        return;
                    }
                }
            }
        }
    }
}