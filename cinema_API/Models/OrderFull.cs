namespace cinema_API.Models
{
    public class OrderFull
    {
        public class SeatShortModel
        {
            public int Row { get; set; }
            public int Place { get; set; }
        }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string HallName { get; set; }
        public int Sum { get; set; }
        public List<SeatShortModel> Seats { get; set; } = new List<SeatShortModel>();
        public OrderFull()
        {

        }
        public OrderFull(string name, DateTime dateTime, string hallName, int sum, IEnumerable<OrderSeat> seats)
        {
            Name = name;
            DateTime = dateTime;
            HallName = hallName;
            Sum = sum;
            foreach (OrderSeat seat in seats)
                Seats.Add(new SeatShortModel { Row = seat.SeatNavigation.Row, Place = seat.SeatNavigation.Place });
        }
    }
}
