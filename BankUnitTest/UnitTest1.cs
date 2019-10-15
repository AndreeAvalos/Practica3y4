using NUnit.Framework;
using Practica3_4.Helpers;
using Practica3_4.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;



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
        public void testTransferencia() {

            String Nombre = "Fernando";
            String Apellido = "Paz";
            Int64 dpi =2679783400101;
            int Cuenta = 002;
            double saldo = 100.0;
            String mail = "fernandopaz@gmail.com";
            String Pass = "1223";

        }

    }
}