using System.Net.Http;
using System.Net.Http.Json;
using ConsumeFootballApi.Models.Dtos;
using ConsumeFootballApi.Services;

public class TeamService : ITeamService
{
    private readonly HttpClient _httpClient;

    public TeamService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<TeamDto>> GetTeamsAsync()
    {
        var response = await _httpClient.GetAsync("TeamsApi");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<TeamDto>>();
    }

    public async Task<TeamDto> GetTeamByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"TeamsApi/{id}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TeamDto>();
    }

    public async Task<bool> CreateTeamAsync(CreateTeamDto createTeamDto)
    {
        var response = await _httpClient.PostAsJsonAsync("TeamsApi", createTeamDto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateTeamAsync(int id, UpdateTeamDto updateTeamDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"TeamsApi/{id}", updateTeamDto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteTeamAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"TeamsApi/{id}");
        return response.IsSuccessStatusCode;
    }
}
