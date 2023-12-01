namespace cinema_API.Models
{
    public class SessionShort
    {
        public int Id { get; set; }
        public string VideoTypeName { get; set; }
        public DateTime DateTime { get; set; }
        public int Price { get; set; }
        public SessionShort(int id, string videoTypeName, DateTime dateTime, int price)
        {
            Id = id;
            VideoTypeName = videoTypeName;
            DateTime = dateTime;
            Price = price;
        }
    }
}
