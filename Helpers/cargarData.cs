using Newtonsoft.Json;
using Practica3_4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Practica3_4.Helpers
{
    public class cargarData
    {
        public static List<Usuario> users;
        public static void cargar()
        {
            string json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\database\usuarios.json");
            users = (List<Usuario>)JsonConvert.DeserializeObject<IEnumerable<Usuario>>(json);
        }
    }
}