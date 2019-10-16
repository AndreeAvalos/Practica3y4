using Newtonsoft.Json;
using Practica3_4.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica3_4
{
    public partial class Saldo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void ConsultarSaldo(object sender, EventArgs e) {

            if (string.IsNullOrEmpty(txtCuenta.Text))
            {
                lblmessage.Text = "El campo esta vacio";
                return;
            }

            string text1 = txtCuenta.Text;
            int num;
            bool res = int.TryParse(text1, out num);
            if (res == false)
            {
                // String is not a number.
                lblmessage.Text = "El campo solo admite numeros enteros";
                return;
            }

            String consulta = txtCuenta.Text;
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\database\usuarios.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var usuario1 = JsonConvert.DeserializeObject<Usuario[]>(json);
                foreach (var datos in usuario1)
                {
                    if (consulta.Equals(datos.Cuenta.ToString()))
                    {
                        lblmessage.Text = datos.Saldo.ToString();
                        return;
                    }
                }
            }
            lblmessage.Text = "Esta cuenta no existe";
        }
    }
}