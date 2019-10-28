using System;

using Newtonsoft.Json;


using Practica3_4.Helpers;
using Practica3_4.Models;

namespace Practica3_4
{
    public static class Registrousuarios
    {

        public static bool CrearUsuario(String Nombres, String Apellidos, Int64 Dpi, int noCuenta, double SaldoIncial, String Mail , String Password) {



            Usuario _data = new Usuario();

            _data.Nombre = Nombres;
            _data.Apellido = Apellidos;
            _data.Dpi = Dpi;
            _data.Cuenta = noCuenta;
            _data.Saldo = SaldoIncial;
            _data.Correo = Mail;
            _data.Password = Password;
            CargarData.Users.Add(_data);
            string json = JsonConvert.SerializeObject(CargarData.Users);
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\database\usuarios.json", json);

            return true;
        }
    }
}