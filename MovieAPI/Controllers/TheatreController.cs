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
    public class TheatreController : ControllerBase
    {
        TheatreService _theatreService;

        public TheatreController(TheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpGet("SelectTheatre")]
        public IActionResult SelectTheatre()
        {
            return Ok(_theatreService.SelectTheatre());
        }

        [HttpPost("AddTheatre")]
        public IActionResult AddTheatre(TheatreModel theatreModel)
        {
            return Ok(_theatreService.AddTheatre(theatreModel));
        }

        [HttpGet("FindTheatreById")]
        public IActionResult FindTheatreById(int theatreId)
        {
            return Ok(_theatreService.FindTheatreById(theatreId));
        }

        [HttpDelete("DeleteTheatre")]
        public IActionResult DeleteTheatre(int theatreId)
        {
            return Ok(_theatreService.DeleteTheatre(theatreId));
        }


        [HttpPut("UpdateTheatre")]
        public IActionResult UpdateTheatre(TheatreModel theatreModel)
        {
            return Ok(_theatreService.UpdateTheatre(theatreModel));

        }
    }
}