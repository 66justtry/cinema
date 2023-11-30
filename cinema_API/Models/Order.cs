namespace cinema_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdSession { get; set; }
        public string Phone { get; set; }
        public int Sum { get; set; }
    }
}
