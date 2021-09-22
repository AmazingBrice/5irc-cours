using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/Devise")]
    [ApiController]
    public class DeviseController : ControllerBase
    {
        private IList<Devise> Devises { get; set; }

        public DeviseController()
        {
            Devises =  new List<Devise>
            {
                new Devise(1, "Dollar", 1.08),
                new Devise(2, "Franc suisse", 1.07),
                new Devise(3, "Yen", 120)
            };
        }

        // GET: api/<DeviseController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return Devises.AsEnumerable();
        }

        // GET api/<DeviseController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        public IActionResult GetById(int id)
        {
            var devise = Devises.FirstOrDefault(x => x.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            return Ok(devise);
        }

        // POST api/<DeviseController>
        [HttpPost]
        public IActionResult Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        // PUT api/<DeviseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeviseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var devise = Devises.FirstOrDefault(x => x.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            Devises.Remove(devise);
            return Ok();
        }
    }
}
