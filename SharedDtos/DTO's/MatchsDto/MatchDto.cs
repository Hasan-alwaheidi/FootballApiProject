using FootballApiProject.Enums;
using System;

namespace FootballApiProject.Models.DTO_s.MatchsDto
{
    public class MatchDto
    {
        public int MatchId { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public DateTime Date { get; set; }
        public string? Score { get; set; }
        public MatchResult? Result { get; set; }
    }
}
