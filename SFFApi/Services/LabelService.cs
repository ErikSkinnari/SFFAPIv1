using Microsoft.EntityFrameworkCore;
using SFFApi.Contracts.V1;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Data;
using SFFApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SFFApi.Services
{
    public class LabelService : ILabelService
    {
        private readonly DataContext _dataContext;

        public LabelService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<LabelDetailedResponse> GetDetailedLabel(Guid loanId)
        {
            var label = await (from loan in _dataContext.MovieLoans
                                 join movie in _dataContext.Movies on loan.Movie.Id equals movie.Id
                                 join studio in _dataContext.Studios on loan.Studio.Id equals studio.Id
                                 join address in _dataContext.Addresses on studio.AddressId equals address.Id
                                 where loan.MovieLoanInstanceGuid == loanId
                                 select new LabelDetailedResponse
                                 {
                                     Recipient = studio.Name,
                                     AddressLine1 = address.AddressLine1,
                                     AddressLine2 = address.AddressLine2,
                                     ZipCode = address.ZipCode,
                                     City = address.City,
                                     Content = "Movie title: " + movie.Title + " MovieId: " + movie.MovieGuid,
                                     DispatchDate = DateTime.Now
                                 }).FirstOrDefaultAsync();

            return label;

            // The old way. Without Linq.

            //var movie = await _movieService.GetMovieByIdAsync(request.MovieId);
            //var studio = await _studioService.GetStudioByIdAsync(request.StudioId);
            //var address = await _dataContext.Addresses.SingleOrDefaultAsync(a => a.Id == studio.AddressId);

            //var label = new LabelDetailedResponse
            //{
            //    Recipient = studio.Name,
            //    AddressLine1 = address.AddressLine1,
            //    AddressLine2 = address.AddressLine2,
            //    ZipCode = address.ZipCode,
            //    City = address.City,
            //    Content = "Movie title: " + movie.Title + " MovieId: " + movie.MovieId,
            //    DispatchDate = DateTime.Now
            //};
        }

        public async Task<EtikettData> GetSimpleLabel(Guid loanId)
        {
            var label = await (from loan in _dataContext.MovieLoans
                               join movie in _dataContext.Movies on loan.Movie.Id equals movie.Id
                               join studio in _dataContext.Studios on loan.Studio.Id equals studio.Id
                               join address in _dataContext.Addresses on studio.AddressId equals address.Id
                               where loan.MovieLoanInstanceGuid == loanId
                               select new EtikettData
                               {
                                   FilmNamn = movie.Title,
                                   Ort = address.City,
                                   Datum = DateTime.Now
                               }).FirstOrDefaultAsync();

            return label;
        }
    }
}
