/* Responsable de manejar operaciones relacionadas con un solo cliente. Por ejemplo:
Obtener el historial de transacciones o pagos de ese cliente.
🔁 Trabaja sobre una instancia de Cliente (no sobre todos). */

using kioskito.Modelos;

namespace kioskito.Servicios
{
    public class ClienteService
    {
        public void RegistrarTransacción(double importe, Cliente cliente)
        {
            if (importe > 0)
            {
                // crear la transacción en la lista del cliente
                cliente.Transacciones.Add(new Transaccion(importe));

                // registrar la transacción en la base de datos
                Database db = new Database();
                db.RegistrarTransaccion(importe, cliente.Id);

                Console.WriteLine("Transacción completada");
            }
            else
            {
                Console.WriteLine("No se puede generar una transacción negativa. Use pagos.");
            }
        }

        /* Se registran pagos tipo "total" o "parcial" */
        public void RegistrarPago(Cliente cliente, Double importe)
        {






            /* double saldoRestante = importe;
            foreach (var transaccion in cliente.Transacciones)
            {
                if (!transaccion.Pagada)
                {
                    if (saldoRestante >= transaccion.Monto)
                    {
                        transaccion.Pagada = true;
                        saldoRestante -= transaccion.Monto;
                    }
                }

            }

            cliente.Pagos.Add(new Pago(importe)); */


        }


        public void CalcularSaldo(Cliente cliente)
        {
            double saldopendiente = cliente.Saldo;
            Console.WriteLine($"el saldo pendiente es de {saldopendiente:C}");
        }


        public void MostrarTransacciones(Cliente cliente)
        {
            foreach (var t in cliente.Transacciones)
            {
                if (!t.Pagada)
                {
                    Console.WriteLine($"{t.Fecha.Date} | Monto: {t.Monto:C} ");
                }
                ;
            }
        }

        public void Mostrarpagos(Cliente cliente)
        {
            foreach (var t in cliente.Transacciones)
            {
                if (t.Pagada)
                {
                    Console.WriteLine($"{t.Fecha.Date} | Monto: {t.Monto:C} ");
                }
                ;
            }
        }


    }
}