using EndProject.Data;
using FootballApiProject.Data;
using FootballApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedDtos.DTO_s.NewsDto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballApiProject.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsApiController : ControllerBase
    {
        private readonly FootballContext _context;

        public NewsApiController(FootballContext context)
        {
            _context = context;
        }

        // GET: api/NewsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDetailsDto>>> GetNewsItems()
        {
            var newsItems = await _context.NewsItems.ToListAsync();

            var newsDtos = newsItems.Select(n => new NewsDetailsDto
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                ImagePath = n.ImagePath,
                DatePublished = n.DatePublished
            }).ToList();

            return Ok(newsDtos);
        }

        // GET: api/NewsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDetailsDto>> GetNewsItem(int id)
        {
            var newsItem = await _context.NewsItems.FindAsync(id);

            if (newsItem == null)
            {
                return NotFound();
            }

            var newsDto = new NewsDetailsDto
            {
                Id = newsItem.Id,
                Title = newsItem.Title,
                Content = newsItem.Content,
                ImagePath = newsItem.ImagePath,
                DatePublished = newsItem.DatePublished
            };

            return Ok(newsDto);
        }

        // POST: api/NewsApi
        [HttpPost]
        public async Task<ActionResult<News>> CreateNewsItem([FromBody] NewsDetailsDto newsDto)
        {
            var newsItem = new News
            {
                Title = newsDto.Title,
                Content = newsDto.Content,
                ImagePath = newsDto.ImagePath,
                DatePublished = newsDto.DatePublished
            };

            _context.NewsItems.Add(newsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNewsItem), new { id = newsItem.Id }, newsDto);
        }

        // PUT: api/NewsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNewsItem(int id, [FromBody] NewsDetailsDto newsDto)
        {
            if (id != newsDto.Id)
            {
                return BadRequest();
            }

            var newsItem = await _context.NewsItems.FindAsync(id);

            if (newsItem == null)
            {
                return NotFound();
            }

            newsItem.Title = newsDto.Title;
            newsItem.Content = newsDto.Content;
            newsItem.ImagePath = newsDto.ImagePath;
            newsItem.DatePublished = newsDto.DatePublished;

            _context.Entry(newsItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.NewsItems.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/NewsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsItem(int id)
        {
            var newsItem = await _context.NewsItems.FindAsync(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            _context.NewsItems.Remove(newsItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
