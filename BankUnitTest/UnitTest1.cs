using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json;
using NUnit.Framework;
using Practica3_4.Helpers;
using Practica3_4.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            cargarData.cargar();
        }

        [Test]
        public void TestLogin()
        {
            string usuario = "alexanderpavelv32@gmail.com";
            string pass = "12345";
            if (string.IsNullOrEmpty(usuario))
            {
                Assert.Fail();
            }
            else if (string.IsNullOrEmpty(pass))
            {
                Assert.Fail();
            }
            Usuario u = UsuariosHelpers.existeUsuario(usuario, pass);
            if (u != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestTransferencia()
        {
            int ClienteRecibe = 206000000, ClienteDa = 206000, ClienteFake = 8000001;
            double saldoPasa = 1000, saldoNoPasa = 1001;
            string passCorrect = "12345", passFake = "54321";
            //test que deberian tirar false
            Respuesta test1_respuesta = TransferenciaHelper.set_Transferencia(ClienteFake, ClienteDa, saldoPasa, passCorrect);
            Respuesta test2_respuesta = TransferenciaHelper.set_Transferencia(ClienteRecibe, ClienteFake, saldoPasa, passCorrect);
            Respuesta test3_respuesta = TransferenciaHelper.set_Transferencia(ClienteRecibe, ClienteDa, saldoPasa, passFake);
            Respuesta test4_respuesta = TransferenciaHelper.set_Transferencia(ClienteRecibe, ClienteDa, saldoNoPasa, passCorrect);
            //prueba que deberia recibir un true de respuesta
            Respuesta test5_respuesta = TransferenciaHelper.set_Transferencia(ClienteRecibe, ClienteDa, saldoPasa, passCorrect);

            if (test1_respuesta.Estado == false) Assert.Pass();
            else Assert.Fail();
            if (test2_respuesta.Estado == false) Assert.Pass();
            else Assert.Fail();
            if (test3_respuesta.Estado == false) Assert.Pass();
            else Assert.Fail();
            if (test4_respuesta.Estado == false) Assert.Pass();
            else Assert.Fail();
            if (test5_respuesta.Estado == true) Assert.Pass();
            else Assert.Fail();
        }

        [Test]
        public void TestConsultaSaldo()
        {
            string cuenta = "206000000";
            int num1;
            if (string.IsNullOrEmpty(cuenta))
            {
                Assert.Fail();
            }

            bool res = int.TryParse(cuenta, out num1);
            if (res == false)
            {
                // String is not a number.
                Assert.Fail();
            }
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\database\usuarios.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var usuario1 = JsonConvert.DeserializeObject<Usuario[]>(json);
                foreach (var datos in usuario1)
                {
                    if (cuenta.Equals(datos.Cuenta.ToString()))
                    {
                        Assert.Pass();
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [Test]
        public void TestPerfilUsuario()
        {
            string usuario = "alexanderpavelv32@gmail.com";
            if (usuario == null || usuario.Equals(""))
            {
                Assert.Fail();
            }

            string path = AppDomain.CurrentDomain.BaseDirectory + @"\database\usuarios.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                var usuario1 = JsonConvert.DeserializeObject<Usuario[]>(json);
                foreach (var datos in usuario1)
                {
                    if (usuario.Equals(datos.Correo.ToString()))
                    {
                        Assert.Pass();
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
        }


        [Test]
        public void TestRegistrarUsuario()
        {

            String Nombre = "Fernando";
            String Apellido = "Paz";
            Int64 dpi = 2679783400101;

            String mail = "fernandopaz@gmail.com";
            String Pass = "1223";

            String cui = dpi.ToString();
            int tamanoDPI = cui.Length;

            String Cuenta = "002";
            int CuentaInt = Int32.Parse(Cuenta);

            double saldo = 250.25;

            bool resultCuenta;

            resultCuenta = Cuenta.All(Char.IsDigit);

            if (string.IsNullOrEmpty(Nombre))
            {
                Assert.Fail();
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                Assert.Fail();
            }
            if (string.IsNullOrEmpty(mail))
            {
                Assert.Fail();
            }
            if (string.IsNullOrEmpty(Pass))
            {
                Assert.Fail();
            }
            if (tamanoDPI < 0 && tamanoDPI > 14)
            {
                Assert.Fail();
            }
            if (resultCuenta == false)
            {
                Assert.Fail();
            }

            bool Esperado;
            Esperado = Practica3_4.Registrousuarios.CrearUsuario(Nombre, Apellido, dpi, CuentaInt, saldo, mail, Pass);

            if (Esperado == true)
            {

                Assert.Pass();

            }

        }


        [Test]
        public void testCambioDia()
        {
            CambioDia fechareal = new CambioDia("", -7.0);
            if (string.IsNullOrEmpty(fechareal.Dia))
            {
                Assert.Pass();
            }
            if (double.IsNegative(fechareal.Cambio))
            {
                Assert.Pass();
            }

            CambioDia fechafake = new CambioDia("19/03/1996", 7.0);
            if (string.IsNullOrEmpty(fechafake.Dia))
            {
                Assert.Fail();
            }
            if (double.IsNegative(fechafake.Cambio))
            {
                Assert.Fail();
            }

            CambioDia pordia = new CambioDia(DateTime.Today.ToString("dd/MM/yy"), 7.7);
            try
            {
                pordia = Practica3_4.TipoCambioService.InvokeServiceCambioDia();
                if (pordia.Dia.Equals(DateTime.Today.ToString("dd/MM/yyyy")))
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [Test]
        public void testCambioFecha()
        {

            CambioFechaInicial fechas1;
            try
            {
                fechas1 = Practica3_4.TipoCambioService.InvokeServiceCambioFecha(DateTime.Today.ToString("dd/MM/yyyy"));
                if (fechas1.totalitems == 2)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception)
            {

            }
            CambioFechaInicial fechas2;
            try
            {
                fechas2 = Practica3_4.TipoCambioService.InvokeServiceCambioFecha("19/03/2020");
                if (fechas2.totalitems == 0)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception) { }
            CambioFechaInicial fechas3;
            try
            {
                fechas3 = Practica3_4.TipoCambioService.InvokeServiceCambioFecha("0");
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }

        }

    }
}