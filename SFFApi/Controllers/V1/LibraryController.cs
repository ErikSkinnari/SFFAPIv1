using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFFApi.Contracts.V1;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Domain;
using SFFApi.Extensions;
using SFFApi.Services;

namespace SFFApi.Controllers.V1
{
    public class LibraryController : Controller
    {
        private readonly IMovieLibraryService _movieLibraryService;

        public LibraryController(IMovieLibraryService movieLibraryService)
        {
            _movieLibraryService = movieLibraryService;
        }

        [HttpGet(ApiRoutes.Movies.Loan)]
        public async Task<ActionResult<MovieResponse>> LoanRequest(MovieLoanRequest request)
        {
            var response = await _movieLibraryService.LoanRequestAsync(request);

            if (response == false)
            {
                return NotFound(new { Error = "Movie not avaliable for the moment" });
            }

            return Ok(new { Success = "Movie loan registered" });
        }

        [HttpGet(ApiRoutes.Movies.Return)]
        public async Task<ActionResult> ReturnRequest(MovieLoanRequest request)
        {
            var response = await _movieLibraryService.ReturnRequestAsync(request);

            if (response == false)
            {
                return NotFound(new { Error = "Loan not active" });
            }

            return Ok(new { Success = "Movie returned" });
        }

        [HttpPost(ApiRoutes.Library.Create)]
        public async Task<IActionResult> Create([FromBody] AddMovieToLibraryRequest request)
        {
            var addNewMovieSuccess = await _movieLibraryService.AddMovieToLibraryAsync(request);

            if (addNewMovieSuccess == false)
            {
                return NotFound(new { Error = "Something went wrong" });
            }

            return Ok();
        }

        [HttpPut(ApiRoutes.Library.Update)]
        public async Task<ActionResult> UpdateMovieInLibrary([FromRoute]Guid Id, int newLicenseLimit)
        {
            var response = await _movieLibraryService.EditMovieInLibraryAsync(
                new UpdateMovieInLibrary 
                { 
                    MovieObjectId = Id, 
                    LicenseLimit = newLicenseLimit 
                });
            if (response == false)
            {
                return NotFound(new { Error = "Update Failed" });
            }

            return Ok();
        }

        [Authorize()]
        [HttpDelete(ApiRoutes.Library.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid Id)
        {
            if (HttpContext.IsAdmin() == false)
            {
                return BadRequest(new { error = "You need to be admin to delete a movie" });
            }

            var libraryObjectDeleted = await _movieLibraryService.RemoveMovieFromLibraryAsync(Id);

            if (libraryObjectDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}