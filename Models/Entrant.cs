namespace EntrantsApi.Models
{
    // This model represents the data structure of an Entrant
    public class Entrant
    {
        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string secret { get; set; }
    }
}