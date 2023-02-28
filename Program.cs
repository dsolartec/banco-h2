namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new();

            bool terminado = false;
            while (!terminado)
            {
                Console.WriteLine("--- Menú ---");
                Console.WriteLine("1. Ver los nombres de los clientes.");
                Console.WriteLine("2. Ver las operaciones admitidas.");
                Console.WriteLine("3. Realizar una operación con un cliente.");
                Console.WriteLine("4. Ver el dinero que posee el banco y cada cliente.");
                Console.WriteLine("5. Limpiar consola.");
                Console.WriteLine("6. Salir.");
                Console.WriteLine("");
                Console.Write("Ingresa una opción: ");

                string? opcion = Console.ReadLine();
                if (opcion == null)
                {
                    Console.WriteLine("> La opción no es válida.");
                    continue;
                }

                switch (opcion)
                {
                    case "1":
                        MenuClientes(banco);
                        break;

                    case "2":
                        MenuOperaciones();
                        break;

                    case "3":
                        Console.WriteLine("--- Operación Banco ---");
                        Console.WriteLine("");

                        string? nombreCliente = null;
                        string? operacion = null;

                        bool operacionTerminada = false;
                        while (!operacionTerminada)
                        {
                            if (nombreCliente == null)
                            {
                                Console.Write("Ingresa el nombre del cliente: ");

                                nombreCliente = Console.ReadLine();
                                if (nombreCliente == null)
                                {
                                    Console.WriteLine("> Ingresa una opción válida.");
                                    continue;
                                }

                                if (!banco.ExisteCliente(nombreCliente))
                                {
                                    Console.WriteLine("> El cliente no existe.");
                                    nombreCliente = null;
                                    continue;
                                }
                            }

                            if (operacion == null)
                            {
                                Console.Write("Ingresa la operación: ");

                                operacion = Console.ReadLine();
                                if (operacion == null)
                                {
                                    Console.WriteLine("> Ingresa una operación válida.");
                                    continue;
                                }

                                if (operacion.ToLower() != "depositar" && operacion.ToLower() != "extraer")
                                {
                                    Console.WriteLine("> El banco no puede realizar esta operación.");
                                    operacion = null;
                                    continue;
                                }
                            }

                            Console.Write("Ingresa la cantidad a {0}: ", operacion.ToLower());

                            string? cantidadS = Console.ReadLine();
                            if (cantidadS == null || !int.TryParse(cantidadS, out int cantidad))
                            {
                                Console.WriteLine("> Ingresa una cantidad válida.");
                                continue;
                            }

                            operacionTerminada = banco.Operar(nombreCliente, operacion, cantidad);
                        }

                        Console.WriteLine("> Operación terminada con éxito.");
                        Console.WriteLine("");
                        break;

                    case "4":
                        banco.DepositosTotales();
                        Console.WriteLine("");
                        break;

                    case "5":
                        Console.Clear();
                        break;

                    case "6":
                        Console.WriteLine("¡Te esperamos pronto!");
                        terminado = true;
                        break;

                    default:
                        Console.WriteLine("> La opción no es válida.");
                        break;
                }
            }

        }

        private static void MenuClientes(Banco banco)
        {
            Console.WriteLine("--- Clientes ---");

            foreach (string nombreCliente in banco.RetonarClientes())
                Console.WriteLine("- {0}", nombreCliente);

            Console.WriteLine();
        }

        private static void MenuOperaciones()
        {
            Console.WriteLine("--- Operaciones ---");
            Console.WriteLine("- Depositar");
            Console.WriteLine("- Extraer");
            Console.WriteLine();
        }
    }
}
