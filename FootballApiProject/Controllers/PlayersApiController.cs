using EndProject.Data;
using FootballApiProject.Data;
using FootballApiProject.Models;
using FootballApiProject.Models.DTO_s.PlayersDto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballApiProject.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersApiController : ControllerBase
    {
        private readonly FootballContext _context;

        public PlayersApiController(FootballContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers()
        {
            var players = await _context.Players
                .Include(p => p.Team)
                .ToListAsync();

            var playersDto = players.Select(p => new PlayerDto
            {
                PlayerId = p.PlayerId,
                Name = p.Name,
                Position = p.Position,
                Nationality = p.Nationality,
                TeamId = p.TeamId,
                TeamName = p.Team.Name,
                ProfilePicturePath = p.ProfilePicturePath,
                Description = p.Description

            }).ToList();

            return Ok(playersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDetailsDto>> GetPlayer(int id)
        {
            var player = await _context.Players
                .Include(p => p.Team)
                .FirstOrDefaultAsync(p => p.PlayerId == id);

            if (player == null)
            {
                return NotFound();
            }

            var playerDetailsDto = new PlayerDetailsDto
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                Position = player.Position,
                Nationality = player.Nationality,
                ProfilePicturePath = player.ProfilePicturePath,
                TeamName = player.Team.Name,
                Description = player.Description
            };

            return Ok(playerDetailsDto);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer([FromBody] CreatePlayerDto dto)
        {
            var team = await _context.Teams.FindAsync(dto.TeamId);
            if (team == null)
            {
                return BadRequest($"Team with ID '{dto.TeamId}' not found.");
            }

            var player = new Player
            {
                Name = dto.Name,
                Position = dto.Position,
                Nationality = dto.Nationality,
                TeamId = dto.TeamId,
                ProfilePicturePath = dto.ProfilePicturePath ?? "/images/players/default.jpg",
                Description = dto.Description
                
            };

            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerId }, player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, [FromBody] UpdatePlayerDto dto)
        {
            if (id != dto.PlayerId)
            {
                return BadRequest();
            }

            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(dto.TeamId);
            if (team == null)
            {
                return BadRequest($"Team with ID '{dto.TeamId}' not found.");
            }

            player.Name = dto.Name;
            player.Position = dto.Position;
            player.Nationality = dto.Nationality;
            player.TeamId = dto.TeamId;
            player.ProfilePicturePath = dto.ProfilePicturePath ?? player.ProfilePicturePath;
            player.Description = dto.Description;

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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
        public async Task<IActionResult> PatchPlayer(int id, [FromBody] JsonPatchDocument<UpdatePlayerDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            var playerDto = new UpdatePlayerDto
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                Position = player.Position,
                Nationality = player.Nationality,
                TeamId = player.TeamId,
                ProfilePicturePath = player.ProfilePicturePath,
                Description = player.Description
            };

            patchDoc.ApplyTo(playerDto, ModelState);

            if (!TryValidateModel(playerDto))
            {
                return ValidationProblem(ModelState);
            }

            player.Name = playerDto.Name;
            player.Position = playerDto.Position;
            player.Nationality = playerDto.Nationality;
            player.TeamId = playerDto.TeamId;
            player.ProfilePicturePath = playerDto.ProfilePicturePath;
            player.Description = playerDto.Description;

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerId == id);
        }
    }
}
