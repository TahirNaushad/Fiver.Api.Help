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

        /// <summary>
        /// Returns a Movie
        /// </summary>
        /// <returns>Existing movie</returns>
        /// <response code="200">if movie found</response>
        /// <response code="404">if movie not found</response>
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult Get(int id)
        {
            var outputModel = new MovieOutputModel();
            return Ok(outputModel);
        }

        /// <summary>
        /// Adds a new movie
        /// </summary>
        /// <remarks>
        /// A sample request body
        /// 
        ///     POST /movies
        ///     {       
        ///         "title": "Thunderball",
        ///         "releaseYear": 1965,
        ///         "summary": "James Bond heads to The Bahamas to recover two nuclear warheads stolen by SPECTRE"
        ///     }
        /// </remarks>
        /// <returns>Newly added movie</returns>
        /// <response code="201">if movie created</response>
        /// <response code="400">if input null or invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(MovieOutputModel), 201)]
        [Produces("application/json", Type = typeof(MovieOutputModel))]
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
