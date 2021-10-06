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

        /// <summary>
        /// Récupération de toutes les comptes utilisateurs
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">Quand des comptes sont bien présents</response>
        /// [ProducesResponseType(typeof(IEnumerable<Devise>), 200)]
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

        /// <summary>
        /// Récupération d'un compte par son id
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the account</param>
        /// <response code="200">When the account id is found</response>
        /// <response code="404">When the account id is not found</response>
        /// [ProducesResponseType(typeof(IActionResult), 200)]
        /// [ProducesResponseType(404)]
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

        /// <summary>
        /// Modification d'un compte par son id et le compte correspondant
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the account</param>
        /// <param name="Compte">The account object and all its properties</param>
        /// <response code="200">When the account id is found</response>
        /// <response code="404">When the account id is not found</response>
        /// <response code="404">When the account id is different from the account id in Compte</response>
        /// [ProducesResponseType(typeof(IActionResult), 200)]
        /// [ProducesResponseType(400)]
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

        /// <summary>
        /// Création d'un nouveau compte
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="devise">Le compte à créer</param>
        /// <response code="200">Si le compte envoyé est valide</response>
        /// <response code="400">Si le compte envoyé est invalide</response>
        /// [ProducesResponseType(typeof(IActionResult), 200)]
        /// [ProducesResponseType(400)]
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

        /// <summary>
        /// Suppression d'un compte
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">L'id du compte à supprimer</param>
        /// <response code="200">Le compte a bien été supprimé</response>
        /// <response code="404">L'id ne correspond à aucun compte</response>
        /// [ProducesResponseType(typeof(IActionResult), 200)]
        /// [ProducesResponseType(404)]
        // DELETE: api/Compte/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
