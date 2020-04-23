using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFFApi.Domain;

namespace SFFApi.Services
{
    public interface IRatingService
    {
        Task<bool> AddRatingAsync(Rating rating);
        Task<RatingResponse> GetRatingByIdAsync(Guid ratingId);
        Task<List<RatingResponse>> GetRatingsAsync();
        Task<Rating> CreateRatingFromRequest(AddRatingRequest request);
        Task<RatingResponse> CreateRatingResponse(Rating rating);
    }
}
