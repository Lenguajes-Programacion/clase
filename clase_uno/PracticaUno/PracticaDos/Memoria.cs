using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PracticaDos
{
    class Memoria
    {
        // Creación de una lista nativa para el manejo de la memoria.
        public List<MemoriaData> db = new List<MemoriaData>();
        public Memoria()
        {
            // Constructor de la clase Memoria, para inicializar nuestra lista
            db = new List<MemoriaData>();
        }
        public void LeerMemoria()
        {
            ConsoleColor currentColor = Console.BackgroundColor;
            string archivoDB = "../../../db.json";
            StreamReader reader = new StreamReader(archivoDB);
            var dbJSON = reader.ReadToEnd();
            var dbObject = JObject.Parse(dbJSON);
            // Prueba de lectura de archivo db.json
            //var result = dbObject.ToString();
            //var result = dbObject["arreglo"].ToString();
            //var result = dbObject["arreglo"][0].ToString();
            // Lectura de json iterable
            int i = 0; // Indice creado manualmente para ubicar facilmente nuestros objetos dentro de la lista db.
            foreach (var item  in dbObject)
            {
                // Iteración individual de cada grupo de datos del objeto json.
                MemoriaData memoriaData = new MemoriaData(item.Key.ToString(), item.Value["operacion"].ToString(),item.Value["resultado"].ToString());
                this.db.Add(memoriaData);
                Console.WriteLine("Dato en memoria: ({0})", i);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} - {1}", memoriaData.fecha.ToLongDateString(),
                memoriaData.fecha.ToLongTimeString());
                Console.ResetColor();
                Console.WriteLine("Operación: {0}",memoriaData.operacion);
                Console.WriteLine("Resultado: {0}",memoriaData.resultado.ToString());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("----------------- \n");
                Console.ForegroundColor = ConsoleColor.White;
                i++;
            }
        }
        public int GetMemoriaData(String key)
        {
            // Encontrar el dato deseado con indice manual en el parseo del json.
            int index = int.Parse(key);
            // Opción Nativa:  para buscar de manera nativa en nuestro List db. Con el indice autogenerado.
            // En tres lineas de código encontramos y reutilizamos el valor que se busca.
            MemoriaData data = db[index];
            // Opción para buscar por medio de indice manual:
            // MemoriaData data = db.Find(item => item.key == index); // Damos un indice para que lo busque y al encontrarlo nos regresa el objeto deseado.
            // Encontrar el dato deseado por la fecha. Accedemos al json nuevamente y buscamos por fecha. 
            // Ya que esta operación no asigna nuevos indices, respeta la estructura acutal.
            // string archivoDB = "../../../db.json";
            // StreamReader reader = new StreamReader(archivoDB);
            // var dbJSON = reader.ReadToEnd();
            // JObject dbObject = JObject.Parse(dbJSON);
            // JToken data = (dbObject as JObject)[key];
            // return (int)data["resultado"];
            return data.resultado;
        }
        public void GuardarMemoria(MemoriaData data)
        {
            db.Add(data);
            int i = 0;
            db.ForEach((MemoriaData memoriaData) =>
            {
                Console.WriteLine("Dato en memoria: ({0})", i);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} - {1}", memoriaData.fecha.ToLongDateString(),
                memoriaData.fecha.ToLongTimeString());
                Console.ResetColor();
                Console.WriteLine("Operación: {0}", memoriaData.operacion);
                Console.WriteLine("Resultado: {0}", memoriaData.resultado.ToString());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("----------------- \n");
                Console.ForegroundColor = ConsoleColor.White;
                i++;
            });
            string json = JsonConvert.SerializeObject(db.ToArray(), Formatting.Indented);
            string archivoDB = "../../../db.json";
            File.WriteAllText(archivoDB, json);
        }
        public void arreglo()
        {
            string[] Colores = { "Rojo", "Blanco", "Morado" };
            //List<string> colores = ["Rojo", "Blanco", "Morado"];
            //colores.Sort();
            Array.Reverse(Colores);
            Array.ForEach(Colores, (item)=>{
                Console.WriteLine(item);
            });
            String color = Array.Find(Colores, (item) => {
                return item.Length > 4;
            });
            Console.WriteLine(color);
            Console.WriteLine("Accede tus colores y separalos con comas(,):");
            String colorUser = Console.ReadLine();
            // Un string se puede convertir en arreglo con su propiedad Split, dándole el patron.
            string[] newColors = colorUser.Split(' ');
            Console.WriteLine(newColors);
        }
        public void multidimensional()
        {
            int[,,] array = new int[4, 2,3];
            Console.WriteLine(array);
        }
    }
    class MemoriaData
    {
        public DateTime fecha;
        public String operacion;
        public int resultado;

        public MemoriaData( String date, String operation, String result)
        {
            fecha = DateTime.Parse(date);
            operacion = operation;
            resultado = int.Parse(result);
        }
    }


}
