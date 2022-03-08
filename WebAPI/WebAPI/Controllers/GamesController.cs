#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTO.GameDTO;
using WebAPI.DTO.PlayerDTO;
using WebAPI.Models;
using WebAPI.Models.DTO.KillDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly HvZContext _context;
        private readonly IMapper _mapper;

        public GamesController(HvZContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Games
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadGameDTO>>> GetGames()
        {
            return _mapper.Map<List<ReadGameDTO>>(await _context.Games.ToListAsync());
        }

        /// <summary>
        /// Gets a game based on Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadGameDTO>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadGameDTO>(game);
        }

        /// <summary>
        /// Gets all Players in a game based on Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReadPlayerDTO>>> GetPlayersInGame(int id)
        {
            var game = _context.Games.Include(g => g.Players).FirstOrDefault(p => p.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<ReadPlayerDTO>>(game.Players.ToList());
        }


        // Will have to resolve relationship in order to make these two work, also add icollection of kills in player

        /// <summary>
        /// Gets all Kills in a game based on Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReadKillDTO>>> GetKillsInGame(int id)
        {
            var game = _context.Games.Include(g => g.Players).ThenInclude(p => p.Kills).FirstOrDefault(p => p.Id == id);

            List<Kill> listOfKills = new List<Kill>();

            if (game == null)
            {
                return NotFound();
            }

            foreach (Player player in game.Players)
            {
                foreach (Kill kill in player.Kills)
                {
                    listOfKills.Add(kill);
                }
            }

            return _mapper.Map<List<ReadKillDTO>>(listOfKills.ToList());
        }



        //[HttpGet("{id}")]
        //public async Task<ActionResult<List<ReadPlayerDTO>>> GetKillInGame(int gameId, int killId)
        //{
        //    var game = _context.Games.Include(g => g.Players).FirstOrDefault(p => p.Id == id);

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    return _mapper.Map<List<ReadPlayerDTO>>(game.Players.ToList());
        //}





        /// <summary>
        /// Update a Game based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, EditGameDTO dtoGame)
        {

            Game domainGame = _mapper.Map<Game>(dtoGame);
            domainGame.Id = id;
            _context.Entry(domainGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a new game
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(CreateGameDTO dtoGame)
        {

            Game gameDomain = _mapper.Map<Game>(dtoGame);
            _context.Games.Add(gameDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetGame",
                new { id = gameDomain.Id },
                _mapper.Map<CreateGameDTO>(gameDomain));
        }

        /// <summary>
        /// Deletes a game based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
