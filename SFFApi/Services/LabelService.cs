using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Domain;
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
        private IMovieService _movieService;
        private IStudioService _studioService;

        public LabelService(IMovieService movieService, IStudioService studioService)
        {
            _movieService = movieService;
            _studioService = studioService;
        }

        public async Task<ILabel> GetDetailedLable(LabelRequest request)
        {
            var movie = await _movieService.GetMovieByIdAsync(request.MovieId);
            var studio = await _studioService.GetStudioByIdAsync(request.StudioId);

            return new XmlLabelResponse(movie, studio);
        }

        public async Task<ILabel> GetSimpleLabel(LabelRequest request)
        {
            var movie = await _movieService.GetMovieByIdAsync(request.MovieId);
            var studio = await _studioService.GetStudioByIdAsync(request.StudioId);

            return new EtikettData(movie, studio);
        }
    }
}
