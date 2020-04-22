using SFFApi.Contracts.V1.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public interface IMovieLibraryService
    {
        Task<bool> AddMovieToLibrary(Movie movie);
        Task<bool> EditMovieInLibrary(Movie movie);
        Task<bool> RemoveMovieFromLibrary(Movie movie);
        Task<bool> LoanRequest(MovieLoanRequest request);
        Task<bool> ReturnRequest(MovieLoanRequest request);
    }
}
