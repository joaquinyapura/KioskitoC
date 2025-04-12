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
                cliente.Transacciones.Add(
                    new Transaccion
                    {
                        Fecha = DateTime.Today,
                        Monto = importe,
                        Pagada = false
                    }
                );
            }
            else
            {
                System.Console.WriteLine("no se puede generar una transacción negativa. use pagos");
            }
        }


        //Registrar un pago (parcial o total).
        public void RegistrarPago(Cliente cliente, Double importe, String tipo)
        {


            double saldoRestante = importe;
            foreach (var t in cliente.Transacciones)
            {
                if (!t.Pagada)
                {
                    if (saldoRestante >= t.Monto)
                    {
                        t.Pagada = true;
                        saldoRestante -= t.Monto;
                    }
                }

            }

            cliente.Pagos.Add(new Pago
            {
                Tipo = "total",
                Fecha = DateTime.Today,
                Monto = importe
            });


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
                    Console.WriteLine($"{t.Fecha.Date} | Monto: {t.Monto:C} ")
                }
            }
        }


    }
}