using Microsoft.EntityFrameworkCore;
using SFFApi.Data;
using SFFApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _dataContext;

        public MovieService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            return await _dataContext.Movies.ToListAsync();
        }

        public async Task<bool> AddMovieAsync(Movie movieToAdd)
        {
            await _dataContext.Movies.AddAsync(movieToAdd);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteMovieAsync(Guid movieId)
        {
            var movie = await GetMovieByIdAsync(movieId);

            if(movie == null)
            {
                return false;
            }

            _dataContext.Movies.Remove(movie);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0; 
        }

        public async Task<Movie> GetMovieByIdAsync(Guid movieId)
        {
            return await _dataContext.Movies.SingleOrDefaultAsync(x => x.MovieId == movieId);
        }        

        public async Task<bool> UpdateMovieAsync(Movie movieToUpdate)
        {
            _dataContext.Movies.Update(movieToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0; // If anything was changed return true.
        }
    }
}
