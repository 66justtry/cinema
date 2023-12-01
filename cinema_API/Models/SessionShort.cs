namespace cinema_API.Models
{
    public class SessionShort
    {
        public int Id { get; set; }
        public string VideoTypeName { get; set; }
        public DateTime DateTime { get; set; }
        public SessionShort(int id, string videoTypeName, DateTime dateTime)
        {
            Id = id;
            VideoTypeName = videoTypeName;
            DateTime = dateTime;
        }
    }
}
