using FootballApiProject.Enums;
using Microsoft.AspNetCore.Http;

namespace FootballApiProject.Models.DTO_s.PlayersDto
{
    public class CreatePlayerDto
    {
        public string Name { get; set; }
        public PlayerPosition Position { get; set; }
        public string Nationality { get; set; }
        public int TeamId { get; set; }
        public string? ProfilePicturePath { get; set; }= "/images/players/playerAvatar.jpg";
    }
}
