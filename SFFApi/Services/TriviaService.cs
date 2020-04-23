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
    public class TriviaService : ITriviaService
    {
        private readonly DataContext _dataContext;
        public TriviaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddTriviaAsync(Trivia trivia)
        {
            await _dataContext.Trivias.AddAsync(trivia);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<Trivia> CreateTriviaFromRequest(AddTriviaRequest request)
        {
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(x => x.MovieGuid.ToString() == request.MovieGuid);
            var studio = await _dataContext.Studios.FirstOrDefaultAsync(x => x.StudioGuid.ToString() == request.StudioGuid);

            var trivia = new Trivia
            {
                TriviaGuid = Guid.NewGuid(),
                MovieId = movie.Id,
                StudioId = studio.Id,
                TriviaText = request.TriviaText
            };

            return trivia;
        }

        public async Task<bool> DeleteTriviaAsync(Guid Id)
        {
            var trivia = await GetTriviaByIdAsync(Id);

            if (trivia == null)
            {
                return false;
            }
            _dataContext.Trivias.Remove(trivia);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Trivia> GetTriviaByIdAsync(Guid triviaId)
        {
            return await _dataContext.Trivias.SingleOrDefaultAsync(x => x.TriviaGuid == triviaId);
        }

        public async Task<Trivia> GetTriviaByMovieGuidAsync(Guid Id)
        {
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(x => x.MovieGuid == Id); // TODO Refactor with Linq Join
            return await _dataContext.Trivias.FirstOrDefaultAsync(x => x.MovieId == movie.Id);
        }

        public async Task<TriviaResponse> CreateTriviaResponse(Trivia trivia)
        {
            var response = await (from t in _dataContext.Trivias
                                  join m in _dataContext.Movies on t.MovieId equals m.Id
                                  where t.Id == trivia.Id
                                  select new TriviaResponse
                                  {
                                      TriviaText = t.TriviaText,
                                      MovieTitle = m.Title
                                  }).FirstOrDefaultAsync();
            return response;
        }
    }
}
