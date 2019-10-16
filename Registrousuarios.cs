using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;


using Practica3_4.Helpers;
using Practica3_4.Models;

namespace Practica3_4
{
    public class Registrousuarios
    {

        public static string CrearUsuario(String Nombres, String Apellidos, Int64 Dpi, int noCuenta, double SaldoIncial, String Mail , String Password) {


            Usuario _data = new Usuario();

            _data.Nombre = Nombres;
            _data.Apellido = Apellidos;
            _data.Dpi = Dpi;
            _data.Cuenta = noCuenta;
            _data.Saldo = SaldoIncial;
            _data.Correo = Mail;
            _data.Password = Password;
            cargarData.users.Add(_data);
            string json = JsonConvert.SerializeObject(cargarData.users);
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\database\usuarios.json", json);

            return json;


        }




    }
}