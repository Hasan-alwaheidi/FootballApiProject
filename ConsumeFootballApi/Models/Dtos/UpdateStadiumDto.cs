namespace ConsumeFootballApi.Models.Dtos
{
    public class UpdateStadiumDto
    {
        public int StadiumId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public IFormFile? Image { get; set; } 
        public string? ExistingImagePath { get; set; }
    }
}
