using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Services
{
    public interface IStudioService
    {
        Task<bool> AddStudioAsync(Studio studioToAdd);
        Task<List<Studio>> GetStudiosAsync();
        Task<Studio> GetStudioByIdAsync(Guid studioId);
        Task<StudioResponse> GetStudioResponseByIdAsync(Guid studioId);
        Task<bool> UpdateStudioAsync(Studio studioToUpdate);
        Task<bool> DeleteStudioAsync(Guid studioId);
        Task<Studio> CreateStudioFromRequest(CreateStudioRequest request);
        Task<ICollection<MovieResponse>> ListMovies(Guid studioId);
    }
}
