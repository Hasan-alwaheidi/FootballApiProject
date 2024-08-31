using FootballApiProject.Enums;

namespace FootballApiProject.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public PlayerPosition Position { get; set; }
        public int TeamId { get; set; }
        public string Nationality { get; set; }
        public string? ProfilePicturePath { get; set; }
        public Team Team { get; set; }

        public string? Description { get; set; }
    }
}
