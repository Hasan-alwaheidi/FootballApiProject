using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDtos.DTO_s.NewsDto
{
    public class CreateNewsDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImagePath { get; set; }
        public DateTime DatePublished { get; set; } = DateTime.Now;
    }
}
