using Microsoft.EntityFrameworkCore;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Data;
using SFFApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Services
{
    public class RatingService : IRatingService
    {
        private readonly DataContext _dataContext;

        public RatingService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AddRatingAsync(Rating rating)
        {
            await _dataContext.Ratings.AddAsync(rating);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<RatingResponse> GetRatingByIdAsync(Guid ratingId)
        {
            var rating = await (from r in _dataContext.Ratings
                                where r.RatingGuid == ratingId
                                select r).FirstOrDefaultAsync();

            var response = await CreateRatingResponse(rating);
            return response;
        }

        public async Task<List<RatingResponse>> GetRatingsAsync()
        {
            var ratings = await _dataContext.Ratings.ToListAsync();

            //List<RatingResponse> response = await ratings.Select(a => CreateRatingResponse(a)).ToList(); // TODO Fix this!

            var response = new List<RatingResponse>();

            foreach(Rating r in ratings)
            {
                response.Add(await CreateRatingResponse(r)); // TODO Legit?
            }

            return response;
        }

        public async Task<Rating> CreateRatingFromRequest(AddRatingRequest request)
        {
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(x => x.MovieGuid.ToString() == request.MovieId);
            var studio = await _dataContext.Studios.FirstOrDefaultAsync(x => x.StudioGuid.ToString() == request.StudioId);

            var rating = new Rating
            {
                RatingGuid = Guid.NewGuid(),
                Score = request.Rating,
                MovieId = movie.Id,
                StudioId = studio.Id,
                TimeOfRating = DateTime.Now                
            };

            return rating;
        }

        public async Task<RatingResponse> CreateRatingResponse(Rating rating)
        {
            var response = await (from r in _dataContext.Ratings
                                  join m in _dataContext.Movies on r.MovieId equals m.Id
                                  join s in _dataContext.Studios on r.StudioId equals s.Id
                                  where r.Id == rating.Id
                                  select new RatingResponse
                                  {
                                      MovieName = m.Title,
                                      StudioName = s.Name,
                                      Score = r.Score
                                  }).FirstOrDefaultAsync();
            return response;
        }
    }
}
