using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace modul9_103082400027.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Stars = new List<string> { "Tim Robbins", "Morgan Freeman" },
                Description = "Two imprisoned men bond over years."
            },
            new Movie
            {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Stars = new List<string> { "Marlon Brando", "Al Pacino" },
                Description = "The aging patriarch transfers control of empire."
            },
            new Movie
            {
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Stars = new List<string> { "Christian Bale", "Heath Ledger" },
                Description = "Batman faces the Joker."
            }
        };

        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            return movies;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            if (id < 0 || id >= movies.Count)
                return NotFound();

            return movies[id];
        }

        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            movies.Add(movie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= movies.Count)
                return NotFound();

            movies.RemoveAt(id);
            return Ok();
        }
    }
}

