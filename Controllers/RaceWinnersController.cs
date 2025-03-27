using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NascarAPI.Models;

namespace NascarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceWinnersController : ControllerBase
    {
        private readonly NascarDbContext _context;

        public RaceWinnersController(NascarDbContext context)
        {
            _context = context;
        }

        // GET: api/RaceWinners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceWinner>>> GetRaceWinners()
        {
            return await _context.RaceWinners.ToListAsync();
        }

        // GET: api/RaceWinners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceWinner>> GetRaceWinner(int id)
        {
            var raceWinner = await _context.RaceWinners.FindAsync(id);

            if (raceWinner == null)
            {
                return NotFound();
            }

            return raceWinner;
        }

        // PUT: api/RaceWinners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceWinner(int id, RaceWinner raceWinner)
        {
            if (id != raceWinner.Id)
            {
                return BadRequest();
            }

            _context.Entry(raceWinner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceWinnerExists(id))
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

        // POST: api/RaceWinners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RaceWinner>> PostRaceWinner(RaceWinner raceWinner)
        {
            _context.RaceWinners.Add(raceWinner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRaceWinner", new { id = raceWinner.Id }, raceWinner);
        }

        // DELETE: api/RaceWinners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaceWinner(int id)
        {
            var raceWinner = await _context.RaceWinners.FindAsync(id);
            if (raceWinner == null)
            {
                return NotFound();
            }

            _context.RaceWinners.Remove(raceWinner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceWinnerExists(int id)
        {
            return _context.RaceWinners.Any(e => e.Id == id);
        }
    }
}
