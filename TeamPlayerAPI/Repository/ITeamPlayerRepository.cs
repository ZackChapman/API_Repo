using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamPlayerAPI.Models;
using TeamPlayerAPI.ViewModel;

namespace TeamPlayerAPI.Repository
{
    public interface ITeamPlayerRepository
    {
        Task<List<Team>> GetTeams();
        Task<List<Player>> GetPlayers();
        Task<TeamPlayerViewModel> GetTeam(int? TeamID);
        Task<TeamPlayerViewModel> GetPlayer(int? PlayerID);
        Task<List<TeamPlayerViewModel>> GetPlayerLastName(string LastName);
        Task<List<TeamPlayerViewModel>> GetTeamByName(string TeamName);
        Task<List<TeamPlayerViewModel>>GetTeamByOrder(string Orderby);
        Task<int> AddTeam(Team team);
        Task<int> AddPlayer(Player player);
        Task<int> DeleteTeam(int? TeamID);
        Task<int> DeletePlayer(int? PlayerID);
        Task UpdateTeam(Team team);
        Task UpdatePlayer(Player player);
    }
}
