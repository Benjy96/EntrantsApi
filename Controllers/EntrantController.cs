using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntrantsApi.Models;

// Generated boilerplate code in this class using the following command:
// dotnet aspnet-codegenerator controller -name EntrantController -async -api -m Entrant -dc EntrantContext -outDir Controllers
namespace EntrantsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EntrantController : ControllerBase
    {
        private readonly EntrantContext _context;

        public EntrantController(EntrantContext context)
        {
            _context = context;
        }

        #region UTILITY METHODS

        /** 
        Creates a version of an Entrant object that omits data 
        (in this case, the "secret" proeprty in Entrant model)
        */
        private static EntrantDTO EntrantToEntrantDTO(Entrant entrant) => new EntrantDTO
        {
            id = entrant.id,
            firstName = entrant.firstName,
            lastName = entrant.lastName
        };

        private bool EntrantExists(long id)
        {
            return _context.Entrant.Any(e => e.id == id);
        }

        #endregion

        #region HTTP METHODS

        // GET: /Entrant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntrantDTO>>> GetEntrants()
        {
            // What you would use if not using the DTO model
            // return await _context.Entrant.ToListAsync();

            // Removes "secret" property from each entrant and returns result to requestor
            return await _context.Entrant
                .Select(e => EntrantToEntrantDTO(e))
                .ToListAsync();
        }

        // GET: /Entrant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntrantDTO>> GetEntrant(long id)
        {
            var entrant = await _context.Entrant.FindAsync(id);

            if (entrant == null)
            {
                return NotFound();
            }

            return EntrantToEntrantDTO(entrant);
        }

        // PUT: /Entrant/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrant(long id, EntrantDTO entrantDTO)
        {
            // If id in PUT request doesn't match id given in body, return 400 code
            if (id != entrantDTO.id)
            {
                return BadRequest();
            }

            var entrant = await _context.Entrant.FindAsync(id);
            if(entrant == null)
            {
                return NotFound();
            }

            entrant.firstName = entrantDTO.firstName;
            entrant.lastName = entrantDTO.lastName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrantExists(id))
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

        // POST: /Entrant
        [HttpPost]
        public async Task<ActionResult<Entrant>> PostEntrant(EntrantDTO entrantDTO)
        {
            var newEntrant = new Entrant
            {
                firstName = entrantDTO.firstName,
                lastName = entrantDTO.lastName
            };

            _context.Entrant.Add(newEntrant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEntrant), new { id = newEntrant.id }, EntrantToEntrantDTO(newEntrant));
        }

        // DELETE: /Entrant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntrant(long id)
        {
            var entrant = await _context.Entrant.FindAsync(id);
            if (entrant == null)
            {
                return NotFound();
            }

            _context.Entrant.Remove(entrant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
