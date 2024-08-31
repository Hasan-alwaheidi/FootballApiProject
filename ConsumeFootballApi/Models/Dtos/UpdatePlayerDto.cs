using FootballApiProject.Enums;

namespace ConsumeFootballApi.Models.Dtos
{
    public class UpdatePlayerDto
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public PlayerPosition Position { get; set; }
        public string Nationality { get; set; }
        public int TeamId { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public string? ExistingProfilePicturePath { get; set; }
    }
}
