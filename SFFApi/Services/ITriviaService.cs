using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Services
{
    public interface ITriviaService
    {
        Task<bool> AddTriviaAsync(Trivia triviaToAdd);
        Task<Trivia> GetTriviaByMovieGuidAsync(Guid Id);
        Task<bool> DeleteTriviaAsync(Guid Id);
        Task<Trivia> CreateTriviaFromRequest(AddTriviaRequest request);
        Task<TriviaResponse> CreateTriviaResponse(Trivia trivia);
    }
}
