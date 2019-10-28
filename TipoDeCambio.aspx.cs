using Practica3_4.Models;
using System;

namespace Practica3_4
{
    public partial class TipoDeCambio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Date_label.Text = Calendar1.SelectedDate.Date.ToString("dd/MM/yyyy");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CambioDia cambiodia = TipoCambioService.InvokeServiceCambioDia();

            response.Text = cambiodia.Dia + "---" + cambiodia.Cambio;



        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Date_label.Text = Calendar1.SelectedDate.Date.ToString("dd/MM/yyyy");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CambioFechaInicial Fechasiniciales = TipoCambioService.InvokeServiceCambioFecha(Calendar1.SelectedDate.Date.ToString("dd/MM/yyyy"));
            string todasfechas = "";
            foreach (CambioFechaInicial.Var var in Fechasiniciales.Fechas)
            {
                todasfechas = $"{todasfechas}Fecha: {var.Fecha} Compra: {var.Compra} Venta: {var.Venta}\n";
            }
            DateResultado.Text = todasfechas;
        }
    }
}