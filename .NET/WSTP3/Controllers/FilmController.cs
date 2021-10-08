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
    public class FilmController : ControllerBase
    {
        private readonly IDataRepository<Film> _dataRepository;

        public FilmController(IDataRepository<Film> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        /// <summary>
        /// Récupération de toutes les films
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">Quand des films sont bien présents</response>
        /// [ProducesResponseType(typeof(IEnumerable<Devise>), 200)]
        // GET: api/Film
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Film>))]
        public async Task<ActionResult<IEnumerable<Film>>> GetAll()
        {
            return await _dataRepository.GetAllAsync();
        }

        [HttpGet("GetFilmByName/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Film))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Film>> GetFilmByName(string title)
        {
            var film = await  _dataRepository.GetByStringAsync(title);

            if (film == null)
            {
                return NotFound("Name invalide");
            }

            return film;
        }

        /// <summary>
        /// Récupération d'un film par son id
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the film</param>
        /// <response code="200">When the film id is found</response>
        /// <response code="404">When the film id is not found</response>
        /// [ProducesResponseType(typeof(IActionResult), 200)]
        /// [ProducesResponseType(404)]
        // GET: api/Film/5
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Film))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilmById(int id)
        {
            var film = await _dataRepository.GetByIdAsync(id);

            if (film == null)
            {
                return NotFound("Id invalide");
            }

            return film;
        }
    }
}
