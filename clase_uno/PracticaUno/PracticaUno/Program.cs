using System;

namespace PracticaUno
{
    class Program
    {
        //Variable de la clase.
        static string nombre = "Roberto";
        static void Main(string[] args)
        {
            //Respondemos con el primer argumento y segundo.
            // Condición se debe de cumplir todas las sentencias si utilizamos &&
            // Condición se debe de cumplir cualquier de las sentencias si utilizamos ||
            // Tipos de comparación: > < == >= <= != 
            // !false, is true
            if (args[0].Length > 0 && args[0] == nombre) // true o false
            {
                Console.WriteLine($"Hello {args[0]}");
            } else
            {
                Console.WriteLine("User unauthorized");
            }
        }
    }
}
