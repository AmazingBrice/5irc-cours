using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/Devise")]
    [ApiController]
    public class DeviseController : ControllerBase
    {
        private List<Devise> _devises { get; set; }

        public DeviseController()
        {
            _devises = new List<Devise>
            {
                new Devise(1, "Dollar", 1.08),
                new Devise(2, "Franc suisse", 1.07),
                new Devise(3, "Yen", 120)
            };
        }

        /// <summary>
        /// Récupération de toutes les dévises
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">Quand des devises sont présentes</response>
        /// [ProducesResponseType(typeof(IEnumerable<Devise>), 200)]
        /// GET: api/Devise
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return _devises.AsEnumerable();
        }

        /// <summary>
        /// Récupération d'une devise par son id
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        /// [ProducesResponseType(typeof(IActionResult), 200)]
        /// [ProducesResponseType(404)]
        /// GET /api/devise/5
        [HttpGet("{id}", Name = "GetDevise")]
        public IActionResult GetById(int id)
        {
            var devise = _devises.FirstOrDefault(x => x.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            return Ok(devise);
        }

        /// <summary>
        /// Création d'une devise
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="devise">La devise à créer</param>
        /// <response code="200">Si la devise envoyée est valide</response>
        /// <response code="400">Si la devise envoyée est invalide</response>
        /// [ProducesResponseType(typeof(IActionResult), 200)]
        /// [ProducesResponseType(400)]
        // POST api/<DeviseController>
        [HttpPost]
        public IActionResult Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        /// <summary>
        /// Création d'une devise
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="devise">La devise à mettre à jour</param>
        /// <response code="200">Si la devise envoyée est valide</response>
        /// <response code="400">Si la devise envoyée est invalide</response>
        /// [ProducesResponseType(typeof(IActionResult), 200)]
        /// [ProducesResponseType(400)]
        // PUT api/<DeviseController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != devise.Id)
            {
                return BadRequest();
            }

            int index = _devises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }

            _devises[index] = devise;

            return NoContent();
        }

        /// <summary>
        /// Création d'une devise
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">La devise id à supprimer</param>
        /// <response code="200">la devise a été supprimée</response>
        /// <response code="404">L'id ne correspond à aucune devise</response>
        /// [ProducesResponseType(typeof(IActionResult), 200)]
        /// [ProducesResponseType(404)]
        // DELETE api/<DeviseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var devise = _devises.FirstOrDefault(x => x.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            _devises.Remove(devise);
            return Ok();
        }
    }
}
