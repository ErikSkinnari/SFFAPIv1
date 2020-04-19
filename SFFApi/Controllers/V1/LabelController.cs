using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SFFApi.Contracts.V1;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Services;

namespace SFFApi.Controllers.V1
{
    public class LabelController : Controller
    {
        private ILabelService _labelService;

        public LabelController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        [HttpGet(ApiRoutes.Label.Simple)]
        [Produces("application/xml")]
        public async Task<IActionResult> GetLabelSimple([FromRoute] Guid MovieId, Guid StudioId)
        {
            var request = new LabelRequest
            {
                MovieId = MovieId,
                StudioId = StudioId
            };

            var response = await _labelService.GetSimpleLabel(request);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.Label.Detailed)]
        [Produces("application/xml")]
        public async Task<IActionResult> GetLabelDetailed([FromRoute] Guid MovieId, Guid StudioId)
        {
            var request = new LabelRequest
            {
                MovieId = MovieId,
                StudioId = StudioId
            };
            var response = await _labelService.GetDetailedLable(request);
            return Ok(response);
        }
    }
}