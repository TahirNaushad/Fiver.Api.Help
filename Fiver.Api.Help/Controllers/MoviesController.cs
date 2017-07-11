using Fiver.Api.Help.Models.Movies;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Fiver.Api.Help.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var outputModel = new List<MovieOutputModel>();
            return Ok(outputModel);
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult Get(int id)
        {
            var outputModel = new MovieOutputModel();
            return Ok(outputModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody]MovieInputModel inputModel)
        {
            var outputModel = new MovieOutputModel();
            return CreatedAtRoute("GetMovie", new { id = outputModel.Id }, outputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]MovieInputModel inputModel)
        {
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePatch(
            int id, [FromBody]JsonPatchDocument<MovieInputModel> patch)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
