using System.Text.Json.Serialization;

namespace FootballApiProject.Models
{
    public class Stadium
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string? ImagePath { get; set; } = "/images/default.jpg";
        [JsonIgnore]
        public ICollection<Team> Teams { get; set; } = new List<Team>();

        public string? Description { get; set; }

    }
}
