using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SFFApi.Contracts.V1;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Services;

namespace SFFApi.Controllers.V1
{
    public class TriviasController : Controller
    {
        private readonly ITriviaService _triviaService;

        public TriviasController(ITriviaService triviaService)
        {
            _triviaService = triviaService;
        }

        [HttpGet(ApiRoutes.Trivias.Get)]
        public async Task<IActionResult> GetTrivia([FromRoute] Guid movieId)
        {
            var response = await _triviaService.GetTriviaByMovieGuidAsync(movieId);

            return Ok(response);
        }

        [HttpPost(ApiRoutes.Trivias.Create)]
        public async Task<IActionResult> Create([FromRoute] AddTriviaRequest request)
        {
            var trivia = await _triviaService.CreateTriviaFromRequest(request);

            var success = await _triviaService.AddTriviaAsync(trivia);

            if (!success)
            {
                return NotFound();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Ratings.Get.Replace("{Id}", trivia.TriviaGuid.ToString());

            var response = await _triviaService.CreateTriviaResponse(trivia);

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.Trivias.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var triviaDeleted = await _triviaService.DeleteTriviaAsync(Id);
            if (triviaDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}