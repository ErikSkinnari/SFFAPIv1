using Microsoft.EntityFrameworkCore;
using SFFApi.Contracts.V1.Requests;
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

        public Studio CreateStudioFromRequest(CreateStudioRequestDto request)
        {
            var studio = new Studio
            {
                StudioId = Guid.NewGuid(),
                Name = request.Name,
                Address = new Address
                {
                    AddressLine1 = request.AddressLine1,
                    AddressLine2 = request.AddressLine2,
                    ZipCode = request.ZipCode,
                    City = request.City
                }
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

        public async Task<Studio> GetStudioByIdAsync(Guid studioId)
        {
            return await _dataContext.Studios.SingleOrDefaultAsync(x => x.StudioId == studioId);
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
    }
}
