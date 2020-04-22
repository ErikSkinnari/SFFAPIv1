using Microsoft.EntityFrameworkCore;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class MovieLibraryService : IMovieLibraryService
    {
        private readonly DataContext _dataContext;
        public readonly List<MovieLibraryObject> MovieLibraryObjects;

        public MovieLibraryService(DataContext dataContext)
        {
            _dataContext = dataContext;
            MovieLibraryObjects = _dataContext.MovieLibrary.ToList();
        }

        public async Task<bool> AddMovieToLibrary(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditMovieInLibrary(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoanRequest(MovieLoanRequest request)
        {
            var requestedMovie = await _dataContext.MovieLibrary.SingleOrDefaultAsync(m => m.MovieId == request.Movie.MovieId);
            if(requestedMovie.Avaliable > 1)
            {
                return false;
            }

            var loanInstance = new MovieLoanInstance
            {
                Movie = request.Movie,
                Studio = request.Studio,
                TimeOfLoan = DateTime.Now
            };

            requestedMovie.Avaliable--; // One movie less avaliable in library

            await _dataContext.MovieLoans.AddAsync(loanInstance);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> ReturnRequest(MovieLoanRequest request)
        {
            var movieLoanToReturn = await _dataContext.MovieLoans.SingleOrDefaultAsync(m => m.Movie.MovieId == request.Movie.MovieId && m.Studio.StudioId == request.Studio.StudioId);
            var requestedMovieLibraryInstance = await _dataContext.MovieLibrary.SingleOrDefaultAsync(m => m.MovieId == request.Movie.MovieId);

            if (movieLoanToReturn == null) // No loan instance found
            {
                return false;
            }

            movieLoanToReturn.TimeOfReturn = DateTime.Now; // Set time of return
            requestedMovieLibraryInstance.Avaliable++; // Add one to the avaliable movies.

            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public Task<bool> RemoveMovieFromLibrary(Movie movie)
        {
            throw new NotImplementedException();
        }

        
    }
}
