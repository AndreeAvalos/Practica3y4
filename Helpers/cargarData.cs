using Newtonsoft.Json;
using Practica3_4.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Practica3_4.Helpers
{
    public static class CargarData
    {
        public static List<Usuario> Users { get; set; }

        public static void cargar()
        {
            string json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\database\usuarios.json");
            Users = (List<Usuario>)JsonConvert.DeserializeObject<IEnumerable<Usuario>>(json);
        }
    }
}