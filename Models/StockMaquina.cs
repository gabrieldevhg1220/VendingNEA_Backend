namespace VendingNEA_Backend.Models
{
    public class StockMaquina
    {
        public int IdStock { get; set; }
        public int IdMaquina { get; set; }
        public int IdProducto { get; set; }
        public int CantidadActual { get; set; }
    }
}