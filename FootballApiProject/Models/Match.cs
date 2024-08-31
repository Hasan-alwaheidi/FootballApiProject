using FootballApiProject.Enums;

namespace FootballApiProject.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime Date { get; set; }
        public string? Score { get; set; }
        public MatchResult? Result { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }
}
