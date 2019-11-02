using Practica3_4.Helpers;
using Practica3_4.Models;
using System;

namespace Practica3_4
{
    public partial class Transferencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Method intentionally left empty.
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int clienteRecibe = Convert.ToInt32(CuentaRecibe.Text), clienteDa = Convert.ToInt32(CuentaDa.Text);
            double monto = Convert.ToDouble(MontoDa.Text);
            string password = Password.Text;

            Respuesta res = TransferenciaHelper.set_Transferencia(clienteRecibe, clienteDa, monto, password);
            respuesta.Text = res.Mensaje;
        }
    }
}