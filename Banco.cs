namespace Banco
{
    class Banco
    {
        private readonly List<Cliente> clientes = new();

        public Banco()
        {
            clientes.Add(new Cliente("Daniel", 0));
            clientes.Add(new Cliente("Felipe", 100_000));
            clientes.Add(new Cliente("María", 25_000));
        }

        public IEnumerable<string> RetonarClientes()
        {
            return clientes.Select(c => c.RetornarNombre());
        }

        public bool ExisteCliente(string nombre)
        {
            return clientes.Find(c => c.RetornarNombre().ToLower() == nombre.ToLower()) != null;
        }

        public bool Operar(string nombreCliente, string operacion, int cantidad)
        {
            Cliente? cliente = clientes.Find(c => c.RetornarNombre().ToLower() == nombreCliente.ToLower());
            if (cliente == null)
            {
                Console.WriteLine("> El cliente no existe.");
                return false;
            }
            
            if (operacion.ToLower() == "depositar")
            {
                bool resultado = cliente.DepositarDinero(cantidad);
                if (resultado)
                    Console.WriteLine("> El dinero ha sido depositado correctamente a la cuenta de {0}.", nombreCliente);
                else
                    Console.WriteLine("> El dinero no ha podido ser depositado a la cuenta de {0}.", nombreCliente);

                return resultado;
            }

            if (operacion.ToLower() == "extraer")
            {
                bool resultado = cliente.ExtraerDinero(cantidad);
                if (resultado)
                    Console.WriteLine("> Se han retirado ${0:N2} de la cuenta de {1}.", cantidad, nombreCliente);
                else
                    Console.WriteLine("> No se ha podido hacer el retiro de la cuenta de {0}.", nombreCliente);
                
                return resultado;
            }

            Console.WriteLine("> El banco no puede realizar esta operación.");
            return false;
        }

        public void DepositosTotales()
        {
            int totales = 0;
            foreach (Cliente cliente in clientes)
            {
                totales += cliente.RetornarMonto();
                Console.WriteLine("> El cliente \"{0}\" tiene ${1:N2}.", cliente.RetornarNombre(), cliente.RetornarMonto());
            }

            Console.WriteLine("");
            Console.WriteLine("> El banco posee ${0:N2}.", totales);
        }

    }
}
