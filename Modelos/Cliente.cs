

namespace kioskito.Modelos
{


    public class Cliente
    {
        public int Id;
        public string NombreCompleto { get; set; }

        public List<Transaccion> Transacciones { get; set; } = new List<Transaccion>();
        public List<Pago> Pagos { get; set; } = new List<Pago>();
        public Double Saldo
        {
            get
            {
                var deudaPendiente = Transacciones
                    .Where(t => !t.Pagada)
                    .Sum(t => t.Monto);

                return deudaPendiente;
            }
            set { }
        }


    }


}

