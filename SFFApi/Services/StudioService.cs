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
    public class StudioService : IStudioService
    {
        private readonly DataContext _dataContext;

        public StudioService(DataContext dataContext)
        {
            _dataContext = dataContext;            
        }

        public async Task<bool> AddStudioAsync(Studio studio)
        {
            await _dataContext.Studios.AddAsync(studio);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<Studio> CreateStudioFromRequest(CreateStudioRequest request)
        {
            var address = new Address
            {
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                ZipCode = request.ZipCode,
                City = request.City
            };

            // Save address to DB
            await _dataContext.Addresses.AddAsync(address);
            var addressCreated = await _dataContext.SaveChangesAsync();
            if (addressCreated < 1)
            {
                // TODO Exeption if address is not properly saved. 
                return null;
            }

            var studio = new Studio
            {
                StudioGuid = Guid.NewGuid(),
                Name = request.Name,
                Address = address
            };

            return studio;
        }

        public async Task<bool> DeleteStudioAsync(Guid studioId)
        {
            var studio = await GetStudioByIdAsync(studioId);

            if (studio == null)
            {
                return false;
            }
            _dataContext.Studios.Remove(studio);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<StudioResponse> GetStudioResponseByIdAsync(Guid studioId)
        {
            var studio = await _dataContext.Studios.SingleOrDefaultAsync(x => x.StudioGuid == studioId);
            var address = await _dataContext.Addresses.SingleOrDefaultAsync(x => x.Id == studio.AddressId);

            var response = new StudioResponse // TODO Refactor
            {
                Name = studio.Name,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                ZipCode = address.ZipCode,
                City = address.City,
                StudioId = studio.StudioGuid
            };

            return response;
        }

        public async Task<Studio> GetStudioByIdAsync(Guid studioId)
        {
            return await _dataContext.Studios.SingleOrDefaultAsync(x => x.StudioGuid == studioId);
        }

        public async Task<List<Studio>> GetStudiosAsync()
        {
            return await _dataContext.Studios.ToListAsync();
        }

        public async Task<bool> UpdateStudioAsync(Studio studioToUpdate)
        {
            _dataContext.Studios.Update(studioToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<ICollection<MovieResponse>> ListMovies(Guid studioId)
        {
            var movieList = await (from loan in _dataContext.MovieLoans
                                   join movie in _dataContext.Movies on loan.Movie.Id equals movie.Id
                                   where loan.Studio.StudioGuid == studioId
                                   select new MovieResponse
                                   {
                                       MovieId = movie.MovieGuid,
                                       Title = movie.Title
                                   }).ToListAsync();
            return movieList;
        }
    }
}
