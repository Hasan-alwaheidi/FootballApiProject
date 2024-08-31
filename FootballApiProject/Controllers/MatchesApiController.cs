using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballApiProject.Data;
using FootballApiProject.Models;
using EndProject.Data;
using FootballApiProject.Models.DTO_s.MatchsDto;
using Microsoft.AspNetCore.JsonPatch;


namespace FootballApiProject.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesApiController : ControllerBase
    {
        private readonly FootballContext _context;

        public MatchesApiController(FootballContext context)
        {
            _context = context;
        }

        // GET: api/MatchesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatches()
        {
            var matches = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .ToListAsync();

            var matchDtos = matches.Select(m => new MatchDto
            {
                MatchId = m.MatchId,
                HomeTeamName = m.HomeTeam.Name,
                AwayTeamName = m.AwayTeam.Name,
                Date = m.Date,
                Score = m.Score,
                Result = m.Result
            }).ToList();

            return Ok(matchDtos);
        }

        // GET: api/MatchesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDetailsDto>> GetMatch(int id)
        {
            var match = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .FirstOrDefaultAsync(m => m.MatchId == id);

            if (match == null)
            {
                return NotFound();
            }

            var matchDetailsDto = new MatchDetailsDto
            {
                MatchId = match.MatchId,
                HomeTeamId = match.HomeTeamId,
                HomeTeamName = match.HomeTeam.Name,
                AwayTeamId = match.AwayTeamId,
                AwayTeamName = match.AwayTeam.Name,
                Date = match.Date,
                Score = match.Score,
                Result = match.Result
            };

            return Ok(matchDetailsDto);
        }

        // POST: api/MatchesApi
        [HttpPost]
        public async Task<ActionResult<Match>> CreateMatch(CreateMatchDto createMatchDto)
        {
            var match = new Match
            {
                HomeTeamId = createMatchDto.HomeTeamId,
                AwayTeamId = createMatchDto.AwayTeamId,
                Date = createMatchDto.Date,
                Score = createMatchDto.Score,
                Result = createMatchDto.Result

            };

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMatch), new { id = match.MatchId }, match);
        }

        // PUT: api/MatchesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatch(int id, UpdateMatchDto updateMatchDto)
        {
            if (id != updateMatchDto.MatchId)
            {
                return BadRequest();
            }

            var match = await _context.Matches.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            match.HomeTeamId = updateMatchDto.HomeTeamId;
            match.AwayTeamId = updateMatchDto.AwayTeamId;
            match.Date = updateMatchDto.Date;
            match.Score = updateMatchDto.Score;
            match.Result = updateMatchDto.Result;

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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
        public async Task<IActionResult> PatchMatch(int id, [FromBody] JsonPatchDocument<UpdateMatchDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            var matchDto = new UpdateMatchDto
            {
                MatchId = match.MatchId,
                HomeTeamId = match.HomeTeamId,
                AwayTeamId = match.AwayTeamId,
                Date = match.Date,
                Score = match.Score,
                Result = match.Result
            };

            patchDoc.ApplyTo(matchDto, ModelState);

            if (!TryValidateModel(matchDto))
            {
                return ValidationProblem(ModelState);
            }

            match.HomeTeamId = matchDto.HomeTeamId;
            match.AwayTeamId = matchDto.AwayTeamId;
            match.Date = matchDto.Date;
            match.Score = matchDto.Score;
            match.Result = matchDto.Result;

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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


        // DELETE: api/MatchesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.MatchId == id);
        }
    }
}
