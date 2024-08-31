using EndProject.Data;
using FootballApiProject.Data;
using FootballApiProject.Models;
using FootballApiProject.Models.DTO_s.PlayersDto;
using FootballApiProject.Models.DTO_s.TeamsDto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballApiProject.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsApiController : ControllerBase
    {
        private readonly FootballContext _context;

        public TeamsApiController(FootballContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDetailsDto>>> GetTeams()
        {
            var teams = await _context.Teams
                .Include(t => t.Stadium)
                .Include(t => t.League)
                .ToListAsync();

            var teamsDto = teams.Select(t => new TeamDetailsDto
            {
                TeamId = t.TeamId,
                Name = t.Name,
                Coach = t.Coach,
                LogoPath = t.LogoPath,
                StadiumName = t.Stadium.Name,
                LeagueName = t.League.Name
            }).ToList();

            return Ok(teamsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDetailsDto>> GetTeam(int id)
        {
            var team = await _context.Teams
                .Include(t => t.Stadium)
                .Include(t => t.League)
                .Include(t => t.Players) // Include players in the team
                .FirstOrDefaultAsync(t => t.TeamId == id);

            if (team == null)
            {
                return NotFound();
            }

            var teamDetailsDto = new TeamDetailsDto
            {
                TeamId = team.TeamId,
                Name = team.Name,
                Coach = team.Coach,
                LogoPath = team.LogoPath,
                StadiumName = team.Stadium.Name,
                LeagueName = team.League.Name,
                Players = team.Players.Select(p => new PlayerDto
                {
                    PlayerId = p.PlayerId,
                    Name = p.Name,
                    Position = p.Position,
                    Nationality = p.Nationality,
                    ProfilePicturePath = p.ProfilePicturePath
                }).ToList()
            };

            return Ok(teamDetailsDto);
        }
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam([FromBody] CreateTeamDto dto)
        {
            // Lookup the StadiumId based on the provided StadiumName
            var stadium = await _context.Stadiums.FirstOrDefaultAsync(s => s.Name == dto.StadiumName);
            if (stadium == null)
            {
                return BadRequest($"Stadium with name '{dto.StadiumName}' not found.");
            }

            // Lookup the LeagueId based on the provided LeagueName
            var league = await _context.Leagues.FirstOrDefaultAsync(l => l.Name == dto.LeagueName);
            if (league == null)
            {
                return BadRequest($"League with name '{dto.LeagueName}' not found.");
            }

            var team = new Team
            {
                Name = dto.Name,
                StadiumId = stadium.StadiumId, // Use the found StadiumId
                LeagueId = league.LeagueId, // Use the found LeagueId
                Coach = dto.Coach,
                LogoPath = dto.LogoPath ?? "/images/default.jpg" // Use a default image if LogoPath is null
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = team.TeamId }, team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, [FromBody] UpdateTeamDto dto)
        {
            if (id != dto.TeamId)
            {
                return BadRequest();
            }

            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            // Lookup the StadiumId based on the provided StadiumName
            var stadium = await _context.Stadiums.FirstOrDefaultAsync(s => s.Name == dto.StadiumName);
            if (stadium == null)
            {
                return BadRequest($"Stadium with name '{dto.StadiumName}' not found.");
            }

            // Lookup the LeagueId based on the provided LeagueName
            var league = await _context.Leagues.FirstOrDefaultAsync(l => l.Name == dto.LeagueName);
            if (league == null)
            {
                return BadRequest($"League with name '{dto.LeagueName}' not found.");
            }

            team.Name = dto.Name;
            team.StadiumId = stadium.StadiumId; // Use the found StadiumId
            team.LeagueId = league.LeagueId; // Use the found LeagueId
            team.Coach = dto.Coach;
            team.LogoPath = dto.LogoPath ?? team.LogoPath; // Keep existing LogoPath if none provided

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTeam(int id, [FromBody] JsonPatchDocument<UpdateTeamDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            var teamDto = new UpdateTeamDto
            {
                TeamId = team.TeamId,
                Name = team.Name,
                Coach = team.Coach,
                StadiumName = await _context.Stadiums
                    .Where(s => s.StadiumId == team.StadiumId)
                    .Select(s => s.Name)
                    .FirstOrDefaultAsync(),
                LeagueName = await _context.Leagues
                    .Where(l => l.LeagueId == team.LeagueId)
                    .Select(l => l.Name)
                    .FirstOrDefaultAsync(),
                LogoPath = team.LogoPath
            };

            patchDoc.ApplyTo(teamDto, ModelState);

            if (!TryValidateModel(teamDto))
            {
                return ValidationProblem(ModelState);
            }

            // Lookup the StadiumId based on the patched StadiumName
            var stadium = await _context.Stadiums.FirstOrDefaultAsync(s => s.Name == teamDto.StadiumName);
            if (stadium == null)
            {
                return BadRequest($"Stadium with name '{teamDto.StadiumName}' not found.");
            }

            // Lookup the LeagueId based on the patched LeagueName
            var league = await _context.Leagues.FirstOrDefaultAsync(l => l.Name == teamDto.LeagueName);
            if (league == null)
            {
                return BadRequest($"League with name '{teamDto.LeagueName}' not found.");
            }

            // Map the patched DTO back to the entity
            team.Name = teamDto.Name;
            team.Coach = teamDto.Coach;
            team.StadiumId = stadium.StadiumId; // Use the found StadiumId
            team.LeagueId = league.LeagueId; // Use the found LeagueId
            team.LogoPath = teamDto.LogoPath;

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }

}

