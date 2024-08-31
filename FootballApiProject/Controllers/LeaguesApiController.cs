using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballApiProject.Data;
using FootballApiProject.Models;
using System.IO;
using EndProject.Data;
using FootballApiProject.Models.DTO_s.LeaguesDto;
using FootballApiProject.Models.DTO_s;
using Microsoft.AspNetCore.JsonPatch;

namespace FootballApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesApiController : ControllerBase
    {
        private readonly FootballContext _context;

        public LeaguesApiController(FootballContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeagueDto>>> GetLeagues()
        {
            return await _context.Leagues
                .Select(league => new LeagueDto
                {
                    LeagueId = league.LeagueId,
                    Name = league.Name,
                    Country = league.Country,
                    Season = league.Season,
                    LogoPath = league.LogoPath,
                    Teams = league.Teams.Select(team => new TeamDto
                    {
                        TeamId = team.TeamId,
                        Name = team.Name,
                        Coach = team.Coach,
                        LogoPath = team.LogoPath
                    }).ToList()
                }).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LeagueDetailsDto>> GetLeague(int id)
        {
            var league = await _context.Leagues
                .Include(l => l.Teams)
                .FirstOrDefaultAsync(l => l.LeagueId == id);

            if (league == null)
            {
                return NotFound();
            }

            var leagueDetailsDto = new LeagueDetailsDto
            {
                LeagueId = league.LeagueId,
                Name = league.Name,
                Country = league.Country,
                Season = league.Season,
                LogoPath = league.LogoPath,
                Teams = league.Teams.Select(t => new TeamDto
                {
                    TeamId = t.TeamId,
                    Name = t.Name,
                    Coach = t.Coach,
                    LogoPath = t.LogoPath
                }).ToList()
            };

            return Ok(leagueDetailsDto);
        }

        [HttpPost]
        public async Task<ActionResult<LeagueDto>> CreateLeague([FromBody] CreateLeagueDto createLeagueDto)
        {
            var league = new League
            {
                Name = createLeagueDto.Name,
                Country = createLeagueDto.Country,
                Season = createLeagueDto.Season,
                LogoPath = createLeagueDto.LogoPath // Just save the path
            };

            _context.Leagues.Add(league);
            await _context.SaveChangesAsync();

            var leagueDto = new LeagueDto
            {
                LeagueId = league.LeagueId,
                Name = league.Name,
                Country = league.Country,
                Season = league.Season,
                LogoPath = league.LogoPath
            };

            return CreatedAtAction(nameof(GetLeague), new { id = league.LeagueId }, leagueDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeague(int id, [FromBody] UpdateLeagueDto leagueDto)
        {
            if (id != leagueDto.LeagueId)
            {
                return BadRequest();
            }

            var league = await _context.Leagues.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }

            // Update properties
            league.Name = leagueDto.Name;
            league.Country = leagueDto.Country;
            league.Season = leagueDto.Season;
            league.LogoPath = leagueDto.LogoPath; // Update the path

            _context.Entry(league).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchLeague(int id, [FromBody] JsonPatchDocument<UpdateLeagueDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var league = await _context.Leagues.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }

            var leagueToPatch = new UpdateLeagueDto
            {
                LeagueId = league.LeagueId,
                Name = league.Name,
                Country = league.Country,
                Season = league.Season,
                LogoPath = league.LogoPath
            };

            patchDoc.ApplyTo(leagueToPatch, ModelState);

            if (!TryValidateModel(leagueToPatch))
            {
                return ValidationProblem(ModelState);
            }

            league.Name = leagueToPatch.Name;
            league.Country = leagueToPatch.Country;
            league.Season = leagueToPatch.Season;
            league.LogoPath = leagueToPatch.LogoPath;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeague(int id)
        {
            var league = await _context.Leagues.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }

            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}

