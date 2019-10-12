using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica3_4.Models
{
    public class Usuario
    {
        private Int64 dpi;
        private string nombre;
        private string apellido;
        private int cuenta;
        private double saldo;
        private string correo;
        private string password;

        public Int64 Dpi { get => dpi; set => dpi = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Cuenta { get => cuenta; set => cuenta = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Password { get => password; set => password = value; }
    }
}