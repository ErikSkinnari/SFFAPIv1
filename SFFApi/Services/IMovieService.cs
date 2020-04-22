using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieByIdAsync(Guid studioId);
        Task<bool> UpdateMovieAsync(Movie movieToUpdate);
        Task<bool> DeleteMovieAsync(Guid movieId);
        Task<bool> AddMovieAsync(Movie movieToAdd);
        Movie CreateMovieFromRequest(CreateMovieRequest request);
    }
}