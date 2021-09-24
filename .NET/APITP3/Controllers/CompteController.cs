using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITP3.Models.EntityFramework;

namespace APITP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteController : ControllerBase
    {
        private readonly TP3DBContext _context;

        public CompteController(TP3DBContext context)
        {
            _context = context;
        }

        // GET: api/Compte
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Compte>))]
        public async Task<ActionResult<IEnumerable<Compte>>> GetCategories()
        {
            return await _context.Comptes.ToListAsync();
        }

        [HttpGet("GetCompteByEmail/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Compte))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compte>> GetCompteByEmail(string email)
        {
            var compte = await _context.Comptes.FirstOrDefaultAsync(c => c.Mel == email);

            if (compte == null)
            {
                return NotFound("Id invalide");
            }

            return compte;
        }

        // GET: api/Compte/5
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Compte))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Compte>> GetCompteById(int id)
        {
            var compte = await _context.Comptes
                .Include(c => c.FavorisCompte)
                .FirstOrDefaultAsync(c => c.CompteId == id);

            if (compte == null)
            {
                return NotFound("Id invalide");
            }

            return compte;
        }

        // PUT: api/Compte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCompte(int id, Compte compte)
        {
            if (id != compte.CompteId)
            {
                return BadRequest("Id incohérent");
            }

            _context.Entry(compte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompteExists(id))
                {
                    return NotFound("Le compte n'existe pas");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Compte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
            _context.Comptes.Add(compte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompte", new { id = compte.CompteId }, compte);
        }

        // DELETE: api/Compte/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCompte(int id)
        //{
        //    var compte = await _context.Categories.FindAsync(id);
        //    if (compte == null)
        //    {
        //        return NotFound("Le compte n'existe pas");
        //    }

        //    _context.Categories.Remove(compte);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool CompteExists(int id)
        {
            return _context.Comptes.Any(e => e.CompteId == id);
        }
    }
}
