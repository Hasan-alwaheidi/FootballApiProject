using FootballApiProject.Enums;
using System;

namespace FootballApiProject.Models.DTO_s.MatchsDto
{
    public class CreateMatchDto
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime Date { get; set; }
        public string? Score { get; set; } 
        public MatchResult? Result { get; set; } 
    }
}
