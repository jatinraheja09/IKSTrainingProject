using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Service;
using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieServices _movieService;

        public MovieController(MovieServices movieServices)
        {
            _movieService = movieServices;
        }

        [HttpGet("SelectMovie")]
        public IActionResult SelectMovie()
        {
            return Ok(_movieService.SelectMovie());
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie(MovieModel movieModel)
        {
            return Ok(_movieService.AddMovie(movieModel));
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int id)
        {
            return Ok(_movieService.DeleteMovie(id));
        }

        [HttpPut("EditMovie")]
        public IActionResult EditMovie(MovieModel movieModel)
        {
            return Ok(_movieService.EditMovie(movieModel));
        }

        [HttpGet("findmoviebyid")]
        public IActionResult FindMovieById(int id)
        {
            return Ok(_movieService.FindMovieById(id));
        }
    }
}
