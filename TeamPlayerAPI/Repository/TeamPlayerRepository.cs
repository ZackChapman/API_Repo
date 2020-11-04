using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamPlayerAPI.Models;
using TeamPlayerAPI.ViewModel;

namespace TeamPlayerAPI.Repository
{
    public class TeamPlayerRepository : ITeamPlayerRepository
    {
        TeamplayerDBContext db;

        public TeamPlayerRepository(TeamplayerDBContext _db)
        {
            db = _db;
        }
        //Get Multiple
        public async Task<List<Team>> GetTeams()
        {
            if (db != null)
            {
                return await db.Teams.ToListAsync();
            }
            return null;
        }
        public async Task<List<Player>> GetPlayers()
        {
            if (db != null)
            {
                return await db.Players.ToListAsync();
            }
            return null;
        }
        //Get Single
        public async Task<TeamPlayerViewModel> GetTeam(int? TeamID)
        {
            if (db != null)
            {
                return await (from t in db.Teams
                    from p in db.Players
                    where t.TeamID == p.TeamID
                    select new TeamPlayerViewModel
                    {
                        TeamID = p.TeamID,
                        TeamName = t.TeamName,
                        Location = t.Location
                    }).FirstOrDefaultAsync();
            }
            return null;
        }
        public async Task<TeamPlayerViewModel> GetPlayer(int? PlayerID)
        {
            if (db != null)
            {
                return await (from p in db.Players
                    from t in db.Teams
                    where p.TeamID == t.TeamID
                    select new TeamPlayerViewModel
                    {
                        PlayerID = p.PlayerID,
                        TeamName = t.TeamName,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                    }).FirstOrDefaultAsync();
            }
            return null;
        }
        // GET QUERY
        public async Task<List<TeamPlayerViewModel>> GetPlayerLastName(string LastName)
        {
            if (db != null)
            {
                var val = await(from p in db.Players
                    from t in db.Teams
                    where p.LastName == LastName
                    select new TeamPlayerViewModel
                    {
                        PlayerID = p.PlayerID,
                        LastName = p.LastName,
                        FirstName = p.FirstName,
                        TeamName = t.TeamName,
                        TeamID = t.TeamID,
                    }).ToListAsync();
                return val;
            }
            return null;
        }
        public async Task<List<TeamPlayerViewModel>> GetTeamByName(string TeamName)
        {
            if (db != null)
            {
                return await (from t in db.Teams
                    from p in db.Players
                    where t.TeamName == TeamName && t.TeamID == p.TeamID
                    select new TeamPlayerViewModel
                    {
                        LastName = p.LastName,
                        FirstName = p.FirstName,
                        TeamName = t.TeamName,
                        PlayerID = p.PlayerID,
                        TeamID = t.TeamID

                    }).ToListAsync();
            }
            return null;
        }
        public async Task<List<TeamPlayerViewModel>> GetTeamByOrder(string Orderby)
        {
            if (db != null)
            {
                var model = new List<TeamPlayerViewModel>();
                if ((Orderby?.ToLower() == "location"))
                {
                    model = await (from t in db.Teams
                        orderby t.Location
                        select new TeamPlayerViewModel
                        {
                            TeamID = t.TeamID,
                            Location = t.Location,
                            TeamName = t.TeamName,
                        }).ToListAsync();
                }
                else if ((Orderby?.ToLower() == "teamname"))
                {
                    model = await (from t in db.Teams
                        orderby t.TeamName
                        select new TeamPlayerViewModel
                        {
                            TeamID = t.TeamID,
                            Location = t.Location,
                            TeamName = t.TeamName,
                        }).ToListAsync();
                }
                else 
                {
                    model= await (from t in db.Teams
                        select new TeamPlayerViewModel
                        {
                            TeamID = t.TeamID,
                            Location = t.Location,
                            TeamName = t.TeamName,
                        }).ToListAsync();
                }

                return model;
            }
            return null;
        }
        //ADD
        public async Task<int> AddTeam(Team team)
        {
            if (db != null)
            {
                await db.Teams.AddAsync(team);
                await db.SaveChangesAsync();
                return (int)team.TeamID;
            }
            return 0;
        }
        public async Task<int> AddPlayer(Player player)
        {
            if (db != null)
            {
                var count = db.Players.Count(p => p.TeamID == player.TeamID);
                if (count < 8)
                {
                    await db.Players.AddAsync(player);
                    await db.SaveChangesAsync();
                    return (int) player.PlayerID;
                }
            }
            return 0;
        }
        //DELETE
        public async Task<int> DeleteTeam(int? TeamID)
        {
            int result = 0;
            if (db != null)
            {
                var team = await db.Teams.FirstOrDefaultAsync(x => x.TeamID == TeamID);
                if (team != null)
                {
                    db.Teams.Remove(team);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        public async Task<int> DeletePlayer(int? PlayerID)
        {
            int result = 0;
            if (db != null)
            {
                var player = await db.Players.FirstOrDefaultAsync(x => x.PlayerID == PlayerID);
                if (player != null)
                {
                    db.Players.Remove(player);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        //PUT
        public async Task UpdateTeam(Team team)
        {
            if (db != null)
            {
                db.Teams.Update(team);
                await db.SaveChangesAsync();
            }
        }
        public async Task UpdatePlayer(Player player)
        {
            if (db != null)
            {
                db.Players.Update(player);
                await db.SaveChangesAsync();
            }
        }
    }
}
