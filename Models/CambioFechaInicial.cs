using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica3_4.Models
{
    public class CambioFechaInicial
    {
        public CambioFechaInicial(int total)
        {
            Fechas = new List<Var>();
            totalitems = total;
        }


        public class Var
        {
            public string Fecha { get; set; }
            public double Venta { get; set; }
            public double Compra { get; set; }
        }

        public List<Var> Fechas { get; set; }
        public int totalitems { get; set; }

        public void addVar(string fecha, double venta, double compra)
        {
            Var variable = new Var();
            variable.Fecha = fecha;
            variable.Venta = venta;
            variable.Compra = compra;

            Fechas.Add(variable);
        }
    }
}
