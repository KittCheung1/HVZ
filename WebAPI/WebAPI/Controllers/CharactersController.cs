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
using WebAPI.Models;
using WebAPI.Models.DTO.Characters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;

        public CharactersController(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all Characters
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCharactersDTO>>> GetCharacters()
        {

            return _mapper.Map<List<ReadCharactersDTO>>(await _context.Characters.ToArrayAsync());
        }

        /// <summary>
        /// Gets Character based on Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCharactersDTO>> GetCharacters(int id)
        {
            var characters = await _context.Characters.FindAsync(id);

            if (characters == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadCharactersDTO>(id);
        }

        /// <summary>
        /// Updates properties of a Character based on the Id
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacters(int id, EditCharactersDTO dtoChar)
        {
            Characters domainChars = _mapper.Map<Characters>(dtoChar);
            _context.Entry(domainChars).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharactersExists(id))
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
        /// Creates a new Character
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Characters>> PostCharacters(CreateCharactersDTO dtoChar)
        {
            Characters domainChars = _mapper.Map<Characters>(dtoChar);
            _context.Characters.Add(domainChars);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacters", new { id = domainChars.Id }, _mapper.Map<CreateCharactersDTO>(dtoChar));
        }

        /// <summary>
        /// Deletes a specific Character based on the Id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacters(int id)
        {
            var characters = await _context.Characters.FindAsync(id);
            if (characters == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(characters);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharactersExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
