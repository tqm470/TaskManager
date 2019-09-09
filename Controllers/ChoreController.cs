using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using TaskManager.Database;

namespace TaskManagerApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChoreController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChoreController(AppDbContext context) => _context = context;

        //GET: api/Chore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chore>>> GetChores()
        {
            var data = _context.Chores.Where(a => a.Owner == User.Identity.Name);
            return await data.ToListAsync();
        }


        //GET: api/Chore
        [HttpGet("{id}")]
        public async Task<ActionResult<Chore>> GetChore(int id)
        {
            var chore = await _context.Chores.FindAsync(id);

            if(chore == null)
            {
                return NotFound();
            }
            if(chore.Owner != User.Identity.Name)
            {
                return Unauthorized();
            }

            return chore;

        }

        //PUT: api/Chore
        [HttpPut("{id}")]
        public async Task<ActionResult<Chore>> PutChore(int id, Chore chore)
        {
            if(id != chore.Id)
            {
                return BadRequest();
            }
            if(chore.Owner != User.Identity.Name)
            {
                return Unauthorized();
            }

            _context.Entry(chore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!_context.Chores.Any(e => e.Id == id))
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


        //POST: api/Chore
        [HttpPost]
        public async Task<ActionResult<Chore>> PostChore(Chore chore)
        {
            _context.Chores.Add(chore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChore", new { Id = chore.Id }, chore);
        }

        //DELETE: api/Chore
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chore>> DeleteChore(int id)
        {
            var chore = await _context.Chores.FindAsync(id);
            if(chore == null)
            {
                NotFound();
            }
            if(chore.Owner != User.Identity.Name)
            {
                return Unauthorized();
            }
            if(!chore.Completed)
            {
                return BadRequest();
            }

            _context.Chores.Remove(chore);
            await _context.SaveChangesAsync();

            return chore;
        }


    }
}