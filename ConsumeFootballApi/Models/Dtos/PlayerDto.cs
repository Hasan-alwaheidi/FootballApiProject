using FootballApiProject.Enums;

namespace ConsumeFootballApi.Models.Dtos
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public PlayerPosition Position { get; set; }
        public string Nationality { get; set; }
        public string TeamName { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}
