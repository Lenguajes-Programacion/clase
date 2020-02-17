using System;
namespace MenuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool close_app = false;
            while (!close_app) {
                Console.WriteLine("Menu App \n");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        HelloWorld.Comprobacion();
                        break;
                    case "2":
                        PracticaDos.Calculadora();
                        break;
                }
            }
        }
    }
    class HelloWorld
    {
        //Variable de la clase.
        static string nombre = "Roberto";
        public static void Comprobacion()
        {
            Console.WriteLine("Usuario:");
            string usuario = Console.ReadLine();
            //Respondemos con el primer argumento y segundo.
            // Condición se debe de cumplir todas las sentencias si utilizamos &&
            // Condición se debe de cumplir cualquier de las sentencias si utilizamos ||
            // Tipos de comparación: > < == >= <= != 
            // !false, is true
            if (usuario.Length > 0 && usuario == nombre) // true o false
            {
                Console.WriteLine($"Hello {usuario}");
            }
            else
            {
                Console.WriteLine("User unauthorized");
            }
        }
    }
}
