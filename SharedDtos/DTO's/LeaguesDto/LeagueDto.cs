using System.Collections.Generic;

namespace FootballApiProject.Models.DTO_s.LeaguesDto
{
    public class LeagueDto
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Season { get; set; }
        public string? LogoPath { get; set; }
        public List<TeamDto> Teams { get; set; }
        public string? Description { get; set; }  

    }
}
