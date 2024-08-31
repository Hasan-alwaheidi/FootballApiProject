using FootballApiProject.Models.DTO_s.PlayersDto;
using System.Collections.Generic;

namespace FootballApiProject.Models.DTO_s.TeamsDto
{
    public class TeamDetailsDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public string? LogoPath { get; set; }
        public string StadiumName { get; set; }
        public string LeagueName { get; set; }
        public ICollection<PlayerDto> Players { get; set; }
        public string? Description { get; set; }

    }
}
