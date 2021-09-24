using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSTP3.Models.EntityFramework;
using WSTP3.Models.DataManager;
using WSTP3.Repository;

namespace WSTP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteController : ControllerBase
    {
        private readonly IDataRepository<Compte> _dataRepository;

        public CompteController(IDataRepository<Compte> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Compte
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Compte>))]
        public async Task<ActionResult<IEnumerable<Compte>>> GetAll()
        {
            return await _dataRepository.GetAllAsync();
        }

        [HttpGet("GetCompteByEmail/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Compte))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compte>> GetCompteByEmail(string email)
        {
            var compte = await  _dataRepository.GetByStringAsync(email);

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
            var compte = await _dataRepository.GetByIdAsync(id);

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
        public async Task<ActionResult> PutCompte(int id, Compte compte)
        {
            if (id != compte.CompteId)
            {
                return BadRequest();
            }

            var compteToUpdate = await _dataRepository.GetByIdAsync(id);

            if (compteToUpdate == null)
            {
                return NotFound();
            }

            await _dataRepository.UpdateAsync(compteToUpdate.Value, compte);

            return NoContent();
        }

        // POST: api/Compte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
            await _dataRepository.AddAsync(compte);

            return CreatedAtAction("GetCompte", new { id = compte.CompteId }, compte);
        }

        // DELETE: api/Compte/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompte(int id)
        {
            var compte = await _dataRepository.GetByIdAsync(id);

            if (compte == null)
            {
                return NotFound("Le compte n'existe pas");
            }

            await _dataRepository.DeleteAsync(compte.Value);

            return NoContent();
        }
    }
}
