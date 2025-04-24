namespace kioskito.Modelos
{



    public class Pago
    {
        public DateTime Fecha { get; set; }
        public Double Monto { get; set; }


        public Pago(double monto)
        {
            Fecha = DateTime.Now;
            Monto = monto;

        }

    }

}

