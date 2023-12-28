namespace cinema_API.Models
{
    public class SeatFull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public int Price { get; set; }
        public bool IsTaken { get; set; } = false;
        public SeatFull(int id, string name, int row, int place, int price, bool isTaken)
        {
            Id = id;
            Name = name;
            Row = row;
            Place = place;
            Price = price;
            IsTaken = isTaken;
        }
    }
}
