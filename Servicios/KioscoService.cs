using kioskito.Modelos;


namespace kioskito.Servicios
{


    public class ListaDeClientes
    {
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();


        public Cliente BuscarClientePorId(string id)
        {
            return Clientes.FirstOrDefault(c => c.Id == id);
        }

        public void MostrarClientes()
        {
            foreach (var cliente in Clientes)
            {
                Console.WriteLine($" {cliente.NombreCompleto} ");
            }
        }


        public bool AgregarCliente(Cliente cliente)
        {
            if (Clientes.Any(c => c.Id == cliente.Id))
            {
                Console.WriteLine("cliente ya existe");
                return false;
            }
            Console.WriteLine("cliente agregado correctamente ");
            Clientes.Add(cliente);
            return true;
        }



    }

}

