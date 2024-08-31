namespace ConsumeFootballApi.Models.Dtos
{
    public class StadiumDto
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string? ImagePath { get; set; }
    }
}