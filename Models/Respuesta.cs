namespace Practica3_4.Models
{
    public class Respuesta
    {
        public Respuesta(string mensaje, bool estado)
        {
            Mensaje = mensaje;
            Estado = estado;
        }

        public string Mensaje { get; set; }
        public bool Estado { get; set; }
    }
}