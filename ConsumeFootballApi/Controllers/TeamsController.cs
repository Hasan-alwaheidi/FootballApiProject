using ConsumeFootballApi.Models.Dtos;
using ConsumeFootballApi.Services;
using Microsoft.AspNetCore.Mvc;

public class TeamsController : Controller
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    public async Task<IActionResult> Index()
    {
        var teams = await _teamService.GetTeamsAsync();
        return View(teams);
    }
    public async Task<IActionResult> Details(int id)
    {
        var team = await _teamService.GetTeamByIdAsync(id);
        if (team == null) return NotFound();
        return View(team);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTeamDto createTeamDto)
    {
        if (ModelState.IsValid)
        {
            var success = await _teamService.CreateTeamAsync(createTeamDto);
            if (success) return RedirectToAction(nameof(Index));
        }
        return View(createTeamDto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var team = await _teamService.GetTeamByIdAsync(id);
        if (team == null) return NotFound();
        return View(team);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, UpdateTeamDto updateTeamDto)
    {
        if (ModelState.IsValid)
        {
            var success = await _teamService.UpdateTeamAsync(id, updateTeamDto);
            if (success) return RedirectToAction(nameof(Index));
        }
        return View(updateTeamDto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var team = await _teamService.GetTeamByIdAsync(id);
        if (team == null) return NotFound();
        return View(team);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var success = await _teamService.DeleteTeamAsync(id);
        if (success) return RedirectToAction(nameof(Index));
        return View();
    }
}
