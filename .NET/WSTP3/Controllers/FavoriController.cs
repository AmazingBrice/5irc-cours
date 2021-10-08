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
using Microsoft.AspNetCore.JsonPatch;

namespace WSTP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriController : ControllerBase
    {
        private readonly IFavoriRepository _dataRepository;

        public FavoriController(IFavoriRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        /// <summary>
        /// Récupération de toutes les favoris
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">Quand des favoris sont bien présents</response>
        /// [ProducesResponseType(typeof(IEnumerable<Devise>), 200)]
        // GET: api/Favori
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Favori>))]
        public async Task<ActionResult<IEnumerable<Favori>>> GetAll()
        {
            return await _dataRepository.GetAllAsync();
        }

        /// <summary>
        /// Récupération des favoris d'un compte par l'id de ce compte
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the account</param>
        /// <response code="200">When the account id is found</response>
        /// <response code="404">When the account id is not found</response>
        /// [ProducesResponseType(typeof(IActionResult), 200)]
        /// [ProducesResponseType(404)]
        // GET: api/Favori/5
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Favori))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Favori>>> GetFavorisByCompteId(int id)
        {
            var favoris = await _dataRepository.GetFavorisByCompteIdAsync(id);

            if (favoris == null)
            {
                return NotFound("Id invalide");
            }

            return favoris;
        }
    }
}
