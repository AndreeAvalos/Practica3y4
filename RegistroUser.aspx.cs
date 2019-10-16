using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Newtonsoft.Json;
using Practica3_4.Helpers;
using Practica3_4.Models;



namespace Practica3_4
{
    public partial class RegistroUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void crear_Click(object sender, EventArgs e)
        {
            
            Int64 d = Int64.Parse(tb_DPI.Text);
            int Cuenta = Int32.Parse(tb_NoCuenta.Text);
            //int Saldo = Int32.Parse(TextBox1.Text);
            double s = double.Parse(TextBox1.Text);

            Practica3_4.Registrousuarios.CrearUsuario(tb_Nombres.Text,tb_Apellidos.Text,d,Cuenta,s,TextBox2.Text,TextBox3.Text);

        }
    }
}