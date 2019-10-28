namespace Practica3_4.Models
{
    public class CambioDia
    {

        public CambioDia(string dia, double cambio)
        {
            Dia = dia;
            Cambio = cambio;
        }

        public string Dia { get; set; }
        public double Cambio { get; set; }
    }
}