using ConsumeFootballApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeFootballApi.Controllers
{
    public class LeaguesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public LeaguesController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration.GetSection("ApiSettings:BaseUrl").Value;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Leagues");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var leagues = JsonConvert.DeserializeObject<List<LeagueDto>>(content);
                return View(leagues);
            }
            return View(new List<LeagueDto>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Leagues/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var league = JsonConvert.DeserializeObject<LeagueDto>(content);
                return View(league);
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLeagueDto createLeagueDto)
        {
            if (ModelState.IsValid)
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(createLeagueDto.Name), nameof(createLeagueDto.Name));
                content.Add(new StringContent(createLeagueDto.Country), nameof(createLeagueDto.Country));
                content.Add(new StringContent(createLeagueDto.Season), nameof(createLeagueDto.Season));

                if (createLeagueDto.Logo != null)
                {
                    var fileContent = new StreamContent(createLeagueDto.Logo.OpenReadStream());
                    content.Add(fileContent, nameof(createLeagueDto.Logo), createLeagueDto.Logo.FileName);
                }

                var response = await _httpClient.PostAsync($"{_apiBaseUrl}Leagues", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "An error occurred while creating the league.");
            }

            return View(createLeagueDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Leagues/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var league = JsonConvert.DeserializeObject<UpdateLeagueDto>(content);
                return View(league);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateLeagueDto updateLeagueDto)
        {
            if (id != updateLeagueDto.LeagueId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(updateLeagueDto.Name), nameof(updateLeagueDto.Name));
                content.Add(new StringContent(updateLeagueDto.Country), nameof(updateLeagueDto.Country));
                content.Add(new StringContent(updateLeagueDto.Season), nameof(updateLeagueDto.Season));

                if (updateLeagueDto.Logo != null)
                {
                    var fileContent = new StreamContent(updateLeagueDto.Logo.OpenReadStream());
                    content.Add(fileContent, nameof(updateLeagueDto.Logo), updateLeagueDto.Logo.FileName);
                }
                else
                {
                    content.Add(new StringContent(updateLeagueDto.ExistingLogoPath ?? string.Empty), nameof(updateLeagueDto.ExistingLogoPath));
                }

                var response = await _httpClient.PutAsync($"{_apiBaseUrl}Leagues/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "An error occurred while updating the league.");
            }

            return View(updateLeagueDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Leagues/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var league = JsonConvert.DeserializeObject<LeagueDto>(content);
                return View(league);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}Leagues/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the league.");
            return View();
        }
    }
}
