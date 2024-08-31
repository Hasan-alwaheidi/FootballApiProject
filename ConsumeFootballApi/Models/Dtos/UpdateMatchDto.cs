using FootballApiProject.Enums;

namespace ConsumeFootballApi.Models.Dtos
{
    public class UpdateMatchDto
    {
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime Date { get; set; }
        public string Score { get; set; }
        public MatchResult? Result { get; set; }
    }
}
