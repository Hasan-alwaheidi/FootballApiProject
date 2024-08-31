using FootballApiProject.Enums;

namespace FootballApiProject.Models.DTO_s.PlayersDto
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public PlayerPosition Position { get; set; }
        public string Nationality { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string? ProfilePicturePath { get; set; }
        public string? Description { get; set; }  // Add Description field


    }
}
