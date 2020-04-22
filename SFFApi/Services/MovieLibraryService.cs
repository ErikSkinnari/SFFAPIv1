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

        public async Task<bool> AddMovieToLibraryAsync(AddMovieToLibraryRequest request)
        {
            var IsAlreadyInLibrary = await _dataContext.MovieLibrary.FirstOrDefaultAsync(x => x.MovieId == request.MovieId);

            if (IsAlreadyInLibrary != null)
            {
                return false;
            }

            var movieLibraryObject = new MovieLibraryObject
            {
                MovieId = request.MovieId,
                LicenseLimit = request.LicenseLimit,
                Avaliable = request.LicenseLimit
            };

            _dataContext.MovieLibrary.Add(movieLibraryObject);

            var added = await _dataContext.SaveChangesAsync();

            return added > 0;
        }

        public async Task<bool> EditMovieInLibraryAsync(UpdateMovieInLibrary movieToUpdate)
        {
            var IsAlreadyInLibrary = await _dataContext.MovieLibrary.FirstOrDefaultAsync(x => x.MovieId == movieToUpdate.MovieObjectId);

            if (IsAlreadyInLibrary == null)
            {
                return false;
            }

            IsAlreadyInLibrary.LicenseLimit = movieToUpdate.LicenseLimit;

            _dataContext.MovieLibrary.Update(IsAlreadyInLibrary);

            var updateSuccess = await _dataContext.SaveChangesAsync();

            return updateSuccess > 0;
        }

        public async Task<bool> LoanRequestAsync(MovieLoanRequest request)
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

        public async Task<bool> ReturnRequestAsync(MovieLoanRequest request)
        {
            var movieLoanToReturn = await _dataContext.MovieLoans.SingleOrDefaultAsync(m => m.Movie.MovieId == request.Movie.MovieId && m.Studio.StudioId == request.Studio.StudioId);
            var requestedMovieLibraryInstance = await _dataContext.MovieLibrary.SingleOrDefaultAsync(m => m.MovieId == request.Movie.MovieId);

            if (movieLoanToReturn == null) // No loan instance found
            {
                return false;
            }

            movieLoanToReturn.IsReturned = true;
            movieLoanToReturn.TimeOfReturn = DateTime.Now;
            requestedMovieLibraryInstance.Avaliable++;

            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> RemoveMovieFromLibraryAsync(Guid movieId)
        {
            var movieToRemove = await _dataContext.MovieLibrary.SingleOrDefaultAsync(m => m.MovieId == movieId);
            if (movieToRemove == null)
            {
                return false;
            }            

            _dataContext.MovieLibrary.Remove(movieToRemove);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }        
    }
}
