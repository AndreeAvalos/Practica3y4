using System;
using System.IO;
using System.Linq;
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
            CargarData.cargar();
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S2583:Conditionally executed blocks should be reachable", Justification = "<pendiente>")]
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
            else
            {
                // Method intentionally left empty.
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

            if (!test1_respuesta.Estado) Assert.Pass();
            else Assert.Fail();
            if (!test2_respuesta.Estado) Assert.Pass();
            else Assert.Fail();
            if (!test3_respuesta.Estado) Assert.Pass();
            else Assert.Fail();
            if (!test4_respuesta.Estado) Assert.Pass();
            else Assert.Fail();
            if (test5_respuesta.Estado) Assert.Pass();
            else Assert.Fail();
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S2583:Conditionally executed blocks should be reachable", Justification = "<pendiente>")]
        public void TestConsultaSaldo()
        {
            string cuenta = "206000000";
            int num1;
            if (string.IsNullOrEmpty(cuenta))
            {
                Assert.Fail();
            }

            bool res = int.TryParse(cuenta, out num1);
            if (!res)
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S2583:Conditionally executed blocks should be reachable", Justification = "<pendiente>")]
        public void TestPerfilUsuario()
        {
            string usuario = "alexanderpavelv32@gmail.com";
            if (string.IsNullOrEmpty(usuario))
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S2583:Conditionally executed blocks should be reachable", Justification = "<pendiente>")]
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
            else
            {
                // Method intentionally left empty.
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
            if (!resultCuenta)
            {
                Assert.Fail();
            }

            bool Esperado;
            Esperado = Practica3_4.Registrousuarios.CrearUsuario(Nombre, Apellido, dpi, CuentaInt, saldo, mail, Pass);

            if (Esperado)
            {
                Assert.Pass();
            }

        }


        [Test]
        public void TestCambioDia()
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

            try
            {
                CambioDia pordia = Practica3_4.TipoCambioService.InvokeServiceCambioDia();
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
        public void TestCambioFecha()
        {
            CambioFechaInicial fechas1;
                fechas1 = Practica3_4.TipoCambioService.InvokeServiceCambioFecha(DateTime.Today.ToString("dd/MM/yyyy"));
                if (fechas1.totalitems > 1)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
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
            catch (Exception) { Assert.Fail(); }
            CambioFechaInicial fechas3;
            try
            {
#pragma warning disable S1854 // Dead stores should be removed
                fechas3 = Practica3_4.TipoCambioService.InvokeServiceCambioFecha("0");
#pragma warning restore S1854 // Dead stores should be removed
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }

        }

    }
}