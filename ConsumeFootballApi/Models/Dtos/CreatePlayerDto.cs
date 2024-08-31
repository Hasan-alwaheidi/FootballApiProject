using FootballApiProject.Enums;

namespace ConsumeFootballApi.Models.Dtos
{
    public class CreatePlayerDto
    {
        public string Name { get; set; }
        public PlayerPosition Position { get; set; }
        public string Nationality { get; set; }
        public int TeamId { get; set; }
        public IFormFile? ProfilePicture { get; set; }
    }
}
