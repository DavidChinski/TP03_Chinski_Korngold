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
                case 2:
                    MostrarEstadisticas();
                break;
                case 3:
                    BuscarCliente();
                break;
                case 4:
                    CambiarEntrada();
                break;
                
            }
        } while (opcion != 5);
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("1. Nueva Inscripción");
        Console.WriteLine("2. Obtener Estadísticas del Evento");
        Console.WriteLine("3. Buscar Cliente");
        Console.WriteLine("4. Cambiar entrada de un Cliente");
        Console.WriteLine("5. Salir");
    }

    private static int IngresarInt(string msj){
        
        int rta;
        do{
            Console.WriteLine(msj);
            rta = int.Parse(Console.ReadLine());

        } while(rta <= 0);

        return rta;
        
    }
    private static string IngresarString(string msj){
        
        string rta;
        do{
            Console.WriteLine(msj);
            rta = Console.ReadLine();

        } while(rta == null || rta == string.Empty);

        return rta;
        
    }

    private static int IngresarEntrada(string msj, int min, int max){

        int rta;
        do{
            Console.WriteLine(msj);
            rta = int.Parse(Console.ReadLine());

        } while(rta < min || rta > max);

        return rta;

    }
    private static void NuevaInscripcion()
    {
        const int ENTRADA_MIN = 1, ENTRADA_MAX = 4;
        int dni, importe = 0, tipoEntrada, id;
        string nombre, apellido;

        dni = IngresarInt("dni?");
        apellido = IngresarString("Apellido?");
        nombre = IngresarString("Nombre?");
        tipoEntrada = IngresarEntrada("Tipo de entrada? (1 para día 1, 2 para día 2, 3 para día 3, 4 para full pass)", ENTRADA_MIN, ENTRADA_MAX);
        

        switch (tipoEntrada)
        {
            case 1:
                importe = 45000;
            break;
            case 2:
                importe = 60000; 
            break;
            case 3:
                importe = 30000; 
            break;
            case 4: 
                importe = 100000;
            break;
            
            
        }

        Cliente cliente = new Cliente(dni, apellido, nombre, DateTime.Now, tipoEntrada, importe);
        id = Ticketera.AgregarCliente(cliente);
        Console.WriteLine($"Cliente agregado con éxito, su id es {id}");
    }

    private static void BuscarCliente()
    {
        int id;

        Console.WriteLine("Id del cliente?");
        id = int.Parse(Console.ReadLine());

        Cliente cliente = Ticketera.BuscarCliente(id);

        if (cliente != null)
            Console.WriteLine($"El nombre del cliente es {cliente.Nombre}, cuyo dni es {cliente.DNI}. Tiene la entrada {cliente.TipoEntrada} por lo que tendra que pagar {cliente.Importe} pesos");
        else
            Console.WriteLine("Cliente no encontrado");
    }

    private static void CambiarEntrada()
    {
        int id, nuevoTipo, nuevoImporte;
        bool sePuedeCambiar;

        Console.WriteLine("Id del cliente?");
        id = int.Parse(Console.ReadLine());

        Console.WriteLine("Nuevo tipo de entrada?");
        nuevoTipo = int.Parse(Console.ReadLine());

        nuevoImporte = CalcularImporte(nuevoTipo);

        sePuedeCambiar = Ticketera.CambiarEntrada(id, nuevoTipo, nuevoImporte);
    
        if (sePuedeCambiar)
            Console.WriteLine("Cambio de entrada hecho.");
        else
            Console.WriteLine("Cambio de entrada fallido o el nuevo importe no es mayor al anterior.");
    }

    private static int CalcularImporte(int tipo)
    {
        const int IMPORTE1 = 45000, IMPORTE2 = 60000, IMPORTE3 = 30000, FULLPASS = 100000;
        switch (tipo)
        {
            case 1: return IMPORTE1;
            case 2: return IMPORTE2;
            case 3: return IMPORTE3;
            case 4: return FULLPASS;
            default: return 0;
        }
    }
    
    private static void MostrarEstadisticas()
    {
        int cantEntradas, recaudado;
        (Dictionary<int, int> entradasPorTipo, Dictionary<int, int> recaudacionPorTipo, int totalRecaudado) = Ticketera.EstadisticasTicketera();
        
        if (entradasPorTipo.Count > 0)
        {
            int totalEntradas = Ticketera.DevolverUltimoID();

            foreach (int tipo in entradasPorTipo.Keys)
            {
                cantEntradas = entradasPorTipo[tipo];
                recaudado = recaudacionPorTipo[tipo];
            
                double porcentaje = (double)cantEntradas / totalEntradas * 100;

                Console.WriteLine($"Tipo de Entrada {tipo}: {cantEntradas} entradas, {porcentaje}% del total, Recaudado: ${recaudado}");
            }

            Console.WriteLine($"Total Recaudado: ${totalRecaudado}");
        }
        else
        {
            Console.WriteLine("Aún no se anotó nadie");
        }
    }   

}
}
