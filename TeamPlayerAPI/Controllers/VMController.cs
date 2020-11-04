using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamPlayerAPI.Models;
using TeamPlayerAPI.Repository;

namespace TeamPlayerAPI.Controllers
{
    [Route("api/teamplayer")]
    [ApiController]
    public class VMController : ControllerBase
    {
        ITeamPlayerRepository teamPlayerRepository;

        public VMController(ITeamPlayerRepository _teamPlayerRepository)
        {
            teamPlayerRepository = _teamPlayerRepository;
        }
        //private readonly TeamplayerDBContext _context;

        //public TeamsController(TeamplayerDBContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Teams
        [HttpGet]
        [Route("GetTeams")]
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                var teams = await teamPlayerRepository.GetTeamByOrder(null);
                if (teams == null)
                {
                    return NotFound();
                }
                return Ok(teams);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetPlayers")]
        public async Task<IActionResult> GetPlayers()
        {
            try
            {
                var players = await teamPlayerRepository.GetPlayers();
                if (players == null)
                {
                    return NotFound();
                }
                return Ok(players);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetTeam")]
        public async Task<IActionResult> GetTeam(int? TeamID)
        {
            if (TeamID == null)
            {
                return BadRequest();
            }
            try
            {
                var post = await teamPlayerRepository.GetTeam(TeamID);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetPlayer")]
        public async Task<IActionResult> GetPlayer(int? PlayerID)
        {
            if (PlayerID == null)
            {
                return BadRequest();
            }
            try
            {
                var post = await teamPlayerRepository.GetPlayer(PlayerID);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetPlayerLastName")]
        public async Task<IActionResult> GetPlayerLastName(string LastName)
        {
            if (LastName == null)
            {
                return BadRequest();
            }
            try
            {
                var player = await teamPlayerRepository.GetPlayerLastName(LastName);
                if (player == null)
                {
                    return NotFound();
                }
                return Ok(player);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetTeamByName")]
        public async Task<IActionResult> GetTeamByName(string TeamName)
        {
            if (TeamName == null)
            {
                return BadRequest();
            }
            try
            {
                var team = await teamPlayerRepository.GetTeamByName(TeamName);
                if (team == null)
                {
                    return NotFound();
                }
                return Ok(team);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetTeamByOrder")]
        public async Task<IActionResult> GetTeamByOder(string Orderby)
        {
            if (Orderby == null)
            {
                return BadRequest();
            }
            try
            {
                var team = await teamPlayerRepository.GetTeamByOrder(Orderby);
                if (team == null)
                {
                    return NotFound();
                }
                return Ok(team);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddTeam")]
        public async Task<IActionResult> AddTeam([FromBody] Team team)
        {

            await teamPlayerRepository.AddTeam(team);

            return CreatedAtAction(nameof(GetTeam), new { id = team.TeamID }, team);
        }
        //public async Task<IActionResult> AddTeam([FromBody] Team team)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var TeamID = await teamPlayerRepository.AddTeam(team);
        //            if (TeamID > 0)
        //            {
        //                return Ok(TeamID);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    return BadRequest();
        //}
        //[HttpPost]
        [HttpPost]
        [Route("AddPlayer")]
        public async Task<IActionResult> AddPlayer([FromBody] Player player)
        {

            await teamPlayerRepository.AddPlayer(player);

            return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerID }, player);
        }
        //public async Task<IActionResult> AddPlayer([FromBody] Player player)

        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var PlayerID = await teamPlayerRepository.AddPlayer(player);
        //            if (PlayerID > 0)
        //            {
        //                return Ok(PlayerID);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    return BadRequest();
        //}
        [HttpDelete]
        [Route("DeleteTeam")]
        public async Task<IActionResult> DeleteTeam(int? TeamID)
        {
            int result = 0;
            if (TeamID == null)
            {
                return BadRequest();
            }
            try
            {
                result = await teamPlayerRepository.DeleteTeam(TeamID);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteTeam")]
        public async Task<IActionResult> DeletePlayer(int? PlayerID)
        {
            int result = 0;
            if (PlayerID == null)
            {
                return BadRequest();
            }
            try
            {
                result = await teamPlayerRepository.DeletePlayer(PlayerID);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateTeam")]
        public async Task<IActionResult> UpdateTeam([FromBody] Team model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await teamPlayerRepository.UpdateTeam(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                        "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("UpdatePlayer")]
        public async Task<IActionResult> UpdatePlayer([FromBody] Player model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await teamPlayerRepository.UpdatePlayer(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                        "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
        //// GET: api/VM
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TeamPlayerViewModel>>> GetTeamPlayerViewModel()
        //{
        //    return await _context.TeamPlayerViewModel.ToListAsync();
        //}

        //// GET: api/VM/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TeamPlayerViewModel>> GetTeamPlayerViewModel(int id)
        //{
        //    var teamPlayerViewModel = await _context.TeamPlayerViewModel.FindAsync(id);

        //    if (teamPlayerViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return teamPlayerViewModel;
        //}

        //// PUT: api/VM/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTeamPlayerViewModel(int id, TeamPlayerViewModel teamPlayerViewModel)
        //{
        //    if (id != teamPlayerViewModel.TeamID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(teamPlayerViewModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TeamPlayerViewModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/VM
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<TeamPlayerViewModel>> PostTeamPlayerViewModel(TeamPlayerViewModel teamPlayerViewModel)
        //{
        //    _context.TeamPlayerViewModel.Add(teamPlayerViewModel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTeamPlayerViewModel", new { id = teamPlayerViewModel.TeamID }, teamPlayerViewModel);
        //}

        //// DELETE: api/VM/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<TeamPlayerViewModel>> DeleteTeamPlayerViewModel(int id)
        //{
        //    var teamPlayerViewModel = await _context.TeamPlayerViewModel.FindAsync(id);
        //    if (teamPlayerViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TeamPlayerViewModel.Remove(teamPlayerViewModel);
        //    await _context.SaveChangesAsync();

        //    return teamPlayerViewModel;
        //}

        //private bool TeamPlayerViewModelExists(int id)
        //{
        //    return _context.TeamPlayerViewModel.Any(e => e.TeamID == id);
        //}
    

