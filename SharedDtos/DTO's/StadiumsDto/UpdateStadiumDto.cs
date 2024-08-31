namespace FootballApiProject.Models.DTO_s.StadiumsDto
{
    public class UpdateStadiumDto
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }  

    }
}
