using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballApiProject.Data;
using FootballApiProject.Models;
using EndProject.Data;
using FootballApiProject.Models.DTO_s.StadiumsDto;
using FootballApiProject.Models.DTO_s;
using Microsoft.AspNetCore.JsonPatch;

namespace FootballApiProject.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsApiController : ControllerBase
    {
        private readonly FootballContext _context;

        public StadiumsApiController(FootballContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StadiumDto>>> GetStadiums()
        {
            return await _context.Stadiums
                .Select(stadium => new StadiumDto
                {
                    StadiumId = stadium.StadiumId,
                    Name = stadium.Name,
                    Location = stadium.Location,
                    Capacity = stadium.Capacity,
                    ImagePath = stadium.ImagePath,
                    Description = stadium.Description
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StadiumDetailsDto>> GetStadium(int id)
        {
            var stadium = await _context.Stadiums
                .Include(s => s.Teams)
                .FirstOrDefaultAsync(s => s.StadiumId == id);

            if (stadium == null)
            {
                return NotFound();
            }

            var stadiumDetailsDto = new StadiumDetailsDto
            {
                StadiumId = stadium.StadiumId,
                Name = stadium.Name,
                Location = stadium.Location,
                Capacity = stadium.Capacity,
                ImagePath = stadium.ImagePath,
                Description = stadium.Description,
                Teams = stadium.Teams.Select(t => new TeamDto
                {
                    TeamId = t.TeamId,
                    Name = t.Name,
                    Coach = t.Coach,
                    LogoPath = t.LogoPath
                }).ToList()
            };

            return Ok(stadiumDetailsDto);
        }


        [HttpPost]
        public async Task<ActionResult<StadiumDto>> CreateStadium([FromBody] CreateStadiumDto createStadiumDto)
        {
            var stadium = new Stadium
            {
                Name = createStadiumDto.Name,
                Location = createStadiumDto.Location,
                Capacity = createStadiumDto.Capacity,
                ImagePath = createStadiumDto.ImagePath,
                Description = createStadiumDto.Description
            };

            _context.Stadiums.Add(stadium);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStadium), new { id = stadium.StadiumId }, stadium);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStadium(int id, [FromBody] UpdateStadiumDto updateStadiumDto)
        {
            if (id != updateStadiumDto.StadiumId)
            {
                return BadRequest();
            }

            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }

            stadium.Name = updateStadiumDto.Name;
            stadium.Location = updateStadiumDto.Location;
            stadium.Capacity = updateStadiumDto.Capacity;
            stadium.ImagePath = updateStadiumDto.ImagePath;
            stadium.Description = updateStadiumDto.Description;

            _context.Entry(stadium).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStadium(int id, [FromBody] JsonPatchDocument<UpdateStadiumDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }

            var stadiumDto = new UpdateStadiumDto
            {
                StadiumId = stadium.StadiumId,
                Name = stadium.Name,
                Location = stadium.Location,
                Capacity = stadium.Capacity,
                ImagePath = stadium.ImagePath,
                Description = stadium.Description
            };

            patchDoc.ApplyTo(stadiumDto, ModelState);

            if (!TryValidateModel(stadiumDto))
            {
                return ValidationProblem(ModelState);
            }

            stadium.Name = stadiumDto.Name;
            stadium.Location = stadiumDto.Location;
            stadium.Capacity = stadiumDto.Capacity;
            stadium.ImagePath = stadiumDto.ImagePath;
            stadium.Description = stadiumDto.Description;

            _context.Entry(stadium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StadiumExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStadium(int id)
        {
            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }

            _context.Stadiums.Remove(stadium);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool StadiumExists(int id)
        {
            return _context.Stadiums.Any(e => e.StadiumId == id);
        }

    }

}

