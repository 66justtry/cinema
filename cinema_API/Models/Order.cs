namespace cinema_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdSession { get; set; }
        public string Phone { get; set; }
        public int Sum { get; set; }
        public Session? SessionNavigation { get; set; }
        public ICollection<OrderSeat> OrderSeatNavigation { get; set; } = new List<OrderSeat>();
    }
}
