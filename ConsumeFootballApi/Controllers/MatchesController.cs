using ConsumeFootballApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeFootballApi.Controllers
{
    public class MatchesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public MatchesController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration.GetSection("ApiSettings:BaseUrl").Value;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Matches");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var matches = JsonConvert.DeserializeObject<List<MatchDto>>(content);
                return View(matches);
            }
            return View(new List<MatchDto>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Matches/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var match = JsonConvert.DeserializeObject<MatchDto>(content);
                return View(match);
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMatchDto createMatchDto)
        {
            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(createMatchDto);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_apiBaseUrl}Matches", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "An error occurred while creating the match.");
            }

            return View(createMatchDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Matches/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var match = JsonConvert.DeserializeObject<UpdateMatchDto>(content);
                return View(match);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateMatchDto updateMatchDto)
        {
            if (id != updateMatchDto.MatchId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(updateMatchDto);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_apiBaseUrl}Matches/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "An error occurred while updating the match.");
            }

            return View(updateMatchDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Matches/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var match = JsonConvert.DeserializeObject<MatchDto>(content);
                return View(match);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}Matches/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the match.");
            return View();
        }
    }
}
