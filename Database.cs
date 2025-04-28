using MySql.Data.MySqlClient;
using System;

public class Database
{
    private string _connectionString = "Server=127.0.0.1;Port=3307;Database=kioskitoc;Uid=root;Pwd=admin;";

    public void TestConnection()
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            try
            {
                conn.Open();
                Console.WriteLine("¡Conexión exitosa a la base de datos MySQL!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexión: " + ex.Message);
            }
        }
    }


    public void InsertarCliente(Cliente cliente)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();

                // Insertar el cliente en la tabla Clientes
                var query = "INSERT INTO Clientes (Id, NombreCompleto, Saldo) VALUES (@Id, @NombreCompleto, @Saldo)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", cliente.Id);
                    cmd.Parameters.AddWithValue("@NombreCompleto", cliente.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Saldo", cliente.Saldo);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Cliente {cliente.NombreCompleto} insertado con éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar cliente: {ex.Message}");
            }
        }
    }












    public void RegistrarTransaccion(double monto, string clienteId)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            // GUID para  Id de la transacción
            string idTransaccion = Guid.NewGuid().ToString();

            string query = "INSERT INTO Transacciones (Id, Id_Cliente, Fecha, Monto, Pagada) " +
                           "VALUES (@Id, @Id_Cliente, @Fecha, @Monto, @Pagada)";
            using (var command = new MySqlCommand(query, connection))
            {
                // Asignar valores a los parámetros de la consulta SQL
                command.Parameters.AddWithValue("@Id", idTransaccion);
                command.Parameters.AddWithValue("@Id_Cliente", clienteId); // Id del cliente
                command.Parameters.AddWithValue("@Fecha", DateTime.Now);
                command.Parameters.AddWithValue("@Monto", monto);
                command.Parameters.AddWithValue("@Pagada", 0); // 0 para un False por defecto

                // Ejecutar la consulta
                command.ExecuteNonQuery();
            }
        }
    }





}
