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
using WebAPI.DTO.PlayerDTO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
      
        private readonly HvZContext _context;
        private readonly IMapper _mapper;

        public PlayersController(HvZContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadPlayerDTO>>> GetPlayers()
        {

            return _mapper.Map<List<ReadPlayerDTO>>(await _context.Players.ToListAsync());
            
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadPlayerDTO>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadPlayerDTO>(player);
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, EditPlayerDTO dtoPlayer)
        {
            Player domainPlayer = _mapper.Map<Player>(dtoPlayer);
            domainPlayer.Id = id;
            _context.Entry(domainPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(CreatePlayerDTO dtoPlayer)
        {

            Player playerDomain = _mapper.Map<Player>(dtoPlayer);
            _context.Players.Add(playerDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPlayer),
                new { id = playerDomain.Id },
                _mapper.Map<CreatePlayerDTO>(playerDomain));
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}
