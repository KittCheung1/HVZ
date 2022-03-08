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
using WebAPI.DTO.UserDTO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HvZContext _context;
        private readonly IMapper _mapper;

        public UsersController(HvZContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadUserDTO>>> GetUsers()
        {
            return _mapper.Map<List<ReadUserDTO>>(await _context.Users.ToListAsync());
        }

        /// <summary>
        /// Gets an User based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadUserDTO>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadUserDTO>(user);
        }

        /// <summary>
        /// Updates an User based on the id (Does not work as intented)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, EditUserDTO dtoUser)
        {

            User domainUser = _mapper.Map<User>(dtoUser);
            domainUser.Id = id;
            _context.Entry(domainUser).State = EntityState.Modified;

            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        /// Creates a new User
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDTO dtoUser)
        {
            User userDomain = _mapper.Map<User>(dtoUser);
            _context.Users.Add(userDomain);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetUser",
                new { id = userDomain.Id },
                _mapper.Map<CreateUserDTO>(dtoUser));
        }

        /// <summary>
        /// Deletes a User based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
