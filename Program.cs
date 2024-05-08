using System;

namespace TP03_Chinski_Korngold
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                MostrarMenu();
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                    NuevaInscripcion();
                    break;

                    
                }

            } while (opcion != 5);

           


            
        }

        public static void NuevaInscripcion()
        {
            int dni;
            string apellido;
            string nombre;
            int tipoEntrada;


        }
        private static void MostrarMenu()
        {
            Console.WriteLine("1. Nueva Inscripción");
           Console.WriteLine("2. Obtener Estadísticas del Evento");
           Console.WriteLine("3. Buscar Cliente");
           Console.WriteLine("4. Cambiar entrada de un Cliente");
           Console.WriteLine("5. Salir");

        }
    }
}