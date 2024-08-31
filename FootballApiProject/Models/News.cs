﻿namespace FootballApiProject.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImagePath { get; set; } 
        public DateTime DatePublished { get; set; }
    }
}
