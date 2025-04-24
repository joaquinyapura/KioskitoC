namespace kioskito.Modelos
{
    public class Transaccion
    {


        public DateTime Fecha { get; set; }
        public Double Monto { get; set; }
        public Boolean Pagada { get; set; }



        public Transaccion(double monto)
        {

            Fecha = DateTime.Today;
            Monto = monto;
            Pagada = false;

        }


    }


}
