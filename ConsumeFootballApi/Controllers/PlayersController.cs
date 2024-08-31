using ConsumeFootballApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeFootballApi.Controllers
{
    public class PlayersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public PlayersController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration.GetSection("ApiSettings:BaseUrl").Value;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Players");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var players = JsonConvert.DeserializeObject<List<PlayerDto>>(content);
                return View(players);
            }
            return View(new List<PlayerDto>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Players/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var player = JsonConvert.DeserializeObject<PlayerDto>(content);
                return View(player);
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePlayerDto createPlayerDto)
        {
            if (ModelState.IsValid)
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(createPlayerDto.Name), nameof(createPlayerDto.Name));
                content.Add(new StringContent(createPlayerDto.Nationality), nameof(createPlayerDto.Nationality));
                content.Add(new StringContent(createPlayerDto.Position.ToString()), nameof(createPlayerDto.Position));
                content.Add(new StringContent(createPlayerDto.TeamId.ToString()), nameof(createPlayerDto.TeamId));

                if (createPlayerDto.ProfilePicture != null)
                {
                    var fileContent = new StreamContent(createPlayerDto.ProfilePicture.OpenReadStream());
                    content.Add(fileContent, nameof(createPlayerDto.ProfilePicture), createPlayerDto.ProfilePicture.FileName);
                }

                var response = await _httpClient.PostAsync($"{_apiBaseUrl}Players", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "An error occurred while creating the player.");
            }

            return View(createPlayerDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Players/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var player = JsonConvert.DeserializeObject<UpdatePlayerDto>(content);
                return View(player);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdatePlayerDto updatePlayerDto)
        {
            if (id != updatePlayerDto.PlayerId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(updatePlayerDto.Name), nameof(updatePlayerDto.Name));
                content.Add(new StringContent(updatePlayerDto.Nationality), nameof(updatePlayerDto.Nationality));
                content.Add(new StringContent(updatePlayerDto.Position.ToString()), nameof(updatePlayerDto.Position));
                content.Add(new StringContent(updatePlayerDto.TeamId.ToString()), nameof(updatePlayerDto.TeamId));

                if (updatePlayerDto.ProfilePicture != null)
                {
                    var fileContent = new StreamContent(updatePlayerDto.ProfilePicture.OpenReadStream());
                    content.Add(fileContent, nameof(updatePlayerDto.ProfilePicture), updatePlayerDto.ProfilePicture.FileName);
                }
                else
                {
                    content.Add(new StringContent(updatePlayerDto.ExistingProfilePicturePath ?? string.Empty), nameof(updatePlayerDto.ExistingProfilePicturePath));
                }

                var response = await _httpClient.PutAsync($"{_apiBaseUrl}Players/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "An error occurred while updating the player.");
            }

            return View(updatePlayerDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}Players/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var player = JsonConvert.DeserializeObject<PlayerDto>(content);
                return View(player);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}Players/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while deleting the player.");
            return View();
        }
    }
}
