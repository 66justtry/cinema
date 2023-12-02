namespace cinema_API.Models
{
    public class CartSessionFull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public int Duration { get; set; }
        public string VideoTypeName { get; set; }
        public string HallName { get; set; }
        public List<SeatFull> Seats { get; set; } = new List<SeatFull>();
        public CartSessionFull(Session session)
        {
            Id = session.Id;
            Name = session.MovieNavigation.Name;
            PhotoUrl = session.MovieNavigation.PhotoUrl;
            Duration = session.MovieNavigation.Duration;
            VideoTypeName = session.VideoTypeNavigation.Name;
            HallName = session.HallNavigation.Name;
            SeatFull seatFull;
            foreach (var s in session.HallNavigation.SeatNavigation)
            {
                bool isTaken = false;
                foreach (var order in session.OrderNavigation)
                {
                    if (order.OrderSeatNavigation.Any(x => x.IdSeat == s.Id))
                    {
                        isTaken = true;
                        break;
                    }
                }
                seatFull = new SeatFull(s.Id, s.SeatTypeNavigation.Name, s.Row, s.Place, session.SessionSeatTypeNavigation.First(x => x.IdSeatType == s.SeatTypeNavigation.Id).Price, isTaken);
                Seats.Add(seatFull);
            }
        }
    }
}
