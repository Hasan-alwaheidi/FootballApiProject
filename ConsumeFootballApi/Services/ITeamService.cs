using ConsumeFootballApi.Models.Dtos;

namespace ConsumeFootballApi.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDto>> GetTeamsAsync();
        Task<TeamDto> GetTeamByIdAsync(int id);
        Task<bool> CreateTeamAsync(CreateTeamDto teamDto);
        Task<bool> UpdateTeamAsync(int id, UpdateTeamDto teamDto);
        Task<bool> DeleteTeamAsync(int id);
    }
}
