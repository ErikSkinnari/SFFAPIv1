using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SFFApi.Contracts.V1;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Domain;
using SFFApi.Extensions;
using SFFApi.Services;

namespace SFFApi.Controllers.V1
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;                
        }

        
        [HttpGet(ApiRoutes.Movies.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _movieService.GetMoviesAsync());
        }

        [HttpGet(ApiRoutes.Movies.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid Id)
        {
            var response = await _movieService.GetMovieByIdAsync(Id);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPut(ApiRoutes.Movies.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid Id, UpdateMovieRequest request)
        {
            var movie = new Movie // TODO refactor
            {
                MovieId = Id,
                Title = request.Title
            };

            var updateSuccess = await _movieService.UpdateMovieAsync(movie);

            if (updateSuccess)
            {
                return Ok(movie);
            }

            return NotFound();
        }

        [Authorize()]
        [HttpDelete(ApiRoutes.Movies.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid Id)
        {
            if(HttpContext.IsAdmin() == false)
            {
                return BadRequest( new { error = "You need to be admin to delete a movie" });
            } 

            var movieDeleted = await _movieService.DeleteMovieAsync(Id);

            if (movieDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost(ApiRoutes.Movies.Create)]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequest request)
        {
            var movie = _movieService.CreateMovieFromRequest(request);

            var success = await _movieService.AddMovieAsync(movie);
            if (!success)
            {
                return NotFound();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Movies.Get.Replace("{Id}", movie.MovieId.ToString());

            var response = new MovieResponse { MovieId = movie.MovieId, Title = movie.Title };

            return Created(locationUri, response);
        }        
    }
}