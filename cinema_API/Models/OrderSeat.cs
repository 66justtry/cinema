namespace cinema_API.Models
{
    public class OrderSeat
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdSeat { get; set; }
        public Order? OrderNavigation { get; set; }
        public Seat? SeatNavigation { get; set; }
    }
}
