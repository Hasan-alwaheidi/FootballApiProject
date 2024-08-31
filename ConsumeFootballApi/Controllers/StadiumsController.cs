using ConsumeFootballApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class StadiumsController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    public StadiumsController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiBaseUrl = configuration.GetSection("ApiSettings:BaseUrl").Value;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}Stadiums");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var stadiums = JsonConvert.DeserializeObject<List<StadiumDto>>(content);
            return View(stadiums);
        }
        return View(new List<StadiumDto>());
    }

    public async Task<IActionResult> Details(int id)
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}Stadiums/{id}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var stadium = JsonConvert.DeserializeObject<StadiumDto>(content);
            return View(stadium);
        }
        return NotFound();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateStadiumDto createStadiumDto)
    {
        if (ModelState.IsValid)
        {
            // Upload the image if present
            if (createStadiumDto.Image != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(createStadiumDto.Image.FileName);
                var extension = Path.GetExtension(createStadiumDto.Image.FileName);
                var imagePath = $"/images/stadiums/{fileName}_{Guid.NewGuid()}{extension}";

                using (var stream = new FileStream(Path.Combine("wwwroot", imagePath), FileMode.Create))
                {
                    await createStadiumDto.Image.CopyToAsync(stream);
                }

                createStadiumDto.ImagePath = imagePath;
            }

            var jsonContent = JsonConvert.SerializeObject(createStadiumDto);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiBaseUrl}Stadiums", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the stadium.");
        }

        return View(createStadiumDto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}Stadiums/{id}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var stadium = JsonConvert.DeserializeObject<UpdateStadiumDto>(content);
            return View(stadium);
        }
        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UpdateStadiumDto updateStadiumDto)
    {
        if (id != updateStadiumDto.StadiumId)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            // Handle image upload if a new image is provided
            if (updateStadiumDto.Image != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updateStadiumDto.Image.FileName);
                var extension = Path.GetExtension(updateStadiumDto.Image.FileName);
                var imagePath = $"/images/stadiums/{fileName}_{Guid.NewGuid()}{extension}";

                using (var stream = new FileStream(Path.Combine("wwwroot", imagePath), FileMode.Create))
                {
                    await updateStadiumDto.Image.CopyToAsync(stream);
                }

                // Optionally, delete the old image if it exists
                if (!string.IsNullOrEmpty(updateStadiumDto.ExistingImagePath))
                {
                    var oldImagePath = Path.Combine("wwwroot", updateStadiumDto.ExistingImagePath);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                updateStadiumDto.ExistingImagePath = imagePath;
            }

            var jsonContent = JsonConvert.SerializeObject(updateStadiumDto);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiBaseUrl}Stadiums/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while updating the stadium.");
        }

        return View(updateStadiumDto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}Stadiums/{id}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var stadium = JsonConvert.DeserializeObject<StadiumDto>(content);
            return View(stadium);
        }
        return NotFound();
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}Stadiums/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }

        ModelState.AddModelError(string.Empty, "An error occurred while deleting the stadium.");
        return View();
    }
}
