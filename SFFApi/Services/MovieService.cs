using Microsoft.AspNetCore.Mvc;
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
    public class MovieService : IMovieService
    {
        private readonly DataContext _dataContext;
        private readonly IMovieLibraryService _movieLibraryService;

        public MovieService(DataContext dataContext, IMovieLibraryService movieLibraryService)
        {
            _dataContext = dataContext;
            _movieLibraryService = movieLibraryService;
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

        public async Task<Movie> GetMovieByIdAsync(Guid MovieId)
        {
            return await _dataContext.Movies.SingleOrDefaultAsync(x => x.MovieId == MovieId);
        }        

        public async Task<bool> UpdateMovieAsync(Movie movieToUpdate)
        {
            _dataContext.Movies.Update(movieToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0; // If anything was changed return true.
        }

        public Movie CreateMovieFromRequest(CreateMovieRequest request)
        {
            var movie = new Movie
            {
                MovieId = Guid.NewGuid(),
                Title = request.Title
            };

            return movie;
        }

        // Request a movie to loan
        public async Task<MovieResponse> LoanRequest(MovieLoanRequest request)
        {
            var movieAvaliable = await _movieLibraryService.LoanRequest(request);

            if(movieAvaliable == false)
            {
                return null;
            }

            return new MovieResponse
            {
                MovieId = request.Movie.MovieId,
                Title = request.Movie.Title
            };
        }

        // Return movie to library after loan
        public async Task<MovieResponse> ReturnRequest(MovieLoanRequest request)
        {
            var loanInstance = await _dataContext.MovieLoans.SingleOrDefaultAsync(x => x.Movie.MovieId == request.Movie.MovieId && x.Studio.StudioId == request.Studio.StudioId);

            if(loanInstance == null)
            {
                return null;
            }

            return new MovieResponse
            {
                MovieId = request.Movie.MovieId,
                Title = request.Movie.Title
            };
        }
    }
}
