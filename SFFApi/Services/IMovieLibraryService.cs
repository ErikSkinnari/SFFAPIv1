using SFFApi.Contracts.V1.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Services
{
    public interface IMovieLibraryService
    {
        Task<bool> AddMovieToLibraryAsync(AddMovieToLibraryRequest movie);
        Task<bool> EditMovieInLibraryAsync(UpdateMovieInLibrary movieToUpdate);
        Task<bool> RemoveMovieFromLibraryAsync(Guid libraryObjectId);
        Task<bool> LoanRequestAsync(MovieLoanRequest request);
        Task<bool> ReturnRequestAsync(MovieLoanRequest request);
    }
}
