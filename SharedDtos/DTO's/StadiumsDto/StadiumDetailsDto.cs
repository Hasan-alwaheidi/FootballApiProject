using System.Collections.Generic;

namespace FootballApiProject.Models.DTO_s.StadiumsDto
{
    public class StadiumDetailsDto
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string? ImagePath { get; set; }
        public ICollection<TeamDto> Teams { get; set; }
    }
}
