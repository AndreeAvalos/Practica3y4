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
            if(u != null)
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