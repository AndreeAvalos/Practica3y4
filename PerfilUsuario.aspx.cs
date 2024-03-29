﻿using Newtonsoft.Json;
using Practica3_4.Helpers;
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
                foreach (var datos in CargarData.Users)
                {
                    if (usuario.Equals(datos.Correo.ToString()))
                    {
                        lbldpi.Text = datos.Dpi.ToString();
                        lblnombre.Text = datos.Nombre.ToString();
                        lblapellido.Text = datos.Apellido.ToString();
                        lblcuenta.Text = datos.Cuenta.ToString();
                        lblsaldo.Text = datos.Saldo.ToString();
                        lblcorreo.Text = datos.Correo.ToString();
                        return;
                    }
                }
            }
        }
    }
}