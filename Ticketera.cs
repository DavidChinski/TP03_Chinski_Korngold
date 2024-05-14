static class Ticketera
{
    private static Dictionary<int, Cliente> DicClientes = new Dictionary<int, Cliente>();
    private static int UltimoIDEntrada = 0;

    public static int DevolverUltimoID()
    {
        return UltimoIDEntrada;
    }

    public static int AgregarCliente(Cliente cliente)
    {
        int id = ++UltimoIDEntrada;
        DicClientes[id] = cliente;
        return id;
    }

    public static Cliente BuscarCliente(int id)
    {
        if (DicClientes.ContainsKey(id)){

                return DicClientes[id];
            }
            else
            return null;
    }

    public static bool CambiarEntrada(int id, int nuevoTipo, int nuevoImporte)
{
    if (DicClientes.ContainsKey(id))
    {
        Cliente cliente = DicClientes[id];
        
        if (nuevoImporte > cliente.Importe)
        {
            cliente.TipoEntrada = nuevoTipo;
            cliente.Importe = nuevoImporte;
            cliente.FechaInscripcion = DateTime.Now;
            return true;
        }
    }
    return false;
}

    public static (Dictionary<int, int>, Dictionary<int, int>, int) EstadisticasTicketera()
    {
        Dictionary<int, int> entradasPorTipo = new Dictionary<int, int>();
        Dictionary<int, int> recaudacionPorTipo = new Dictionary<int, int>();
        int totalRecaudado = 0;

        foreach (Cliente cliente in DicClientes.Values)
        {
            if (!entradasPorTipo.ContainsKey(cliente.TipoEntrada))
            {
                entradasPorTipo[cliente.TipoEntrada] = 0;
                recaudacionPorTipo[cliente.TipoEntrada] = 0;
            }
            entradasPorTipo[cliente.TipoEntrada]++;
            recaudacionPorTipo[cliente.TipoEntrada] += cliente.Importe;
            totalRecaudado += cliente.Importe;
        }
        return (entradasPorTipo, recaudacionPorTipo, totalRecaudado); }
}