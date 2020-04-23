using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFFApi.Contracts.V1;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Services;

namespace SFFApi.Controllers.V1
{
    public class RatingsController : Controller
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet(ApiRoutes.Ratings.GetAll)]
        public async Task<IActionResult> GetAllRatings()
        {
            var response = await _ratingService.GetRatingsAsync();

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Ratings.Get)]
        public async Task<IActionResult> GetRating([FromRoute] Guid Id)
        {
            var response = await _ratingService.GetRatingByIdAsync(Id);

            return Ok(response);
        }

        [HttpPost(ApiRoutes.Ratings.Create)]
        public async Task<IActionResult> Create([FromRoute] AddRatingRequest request)
        {
            var rating = await _ratingService.CreateRatingFromRequest(request);

            var success = await _ratingService.AddRatingAsync(rating);

            if (!success)
            {
                return NotFound();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Ratings.Get.Replace("{Id}", rating.RatingGuid.ToString());

            var response = await _ratingService.CreateRatingResponse(rating);

            return Created(locationUri, response);
        }
    }
}