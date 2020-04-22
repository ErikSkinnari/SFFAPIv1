﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SFFApi.Contracts.V1;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Services;

namespace SFFApi.Controllers.V1
{
    public class LabelController : Controller
    {
        private readonly ILabelService _labelService;

        public LabelController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        /// <summary>
        /// Returnes the required xml-formatted label specified in the assignement.
        /// </summary>
        [HttpGet(ApiRoutes.Label.Simple)]
        [Produces("application/xml")]
        public async Task<ActionResult<EtikettData>> GetLabelSimple([FromRoute]Guid movieId, [FromRoute]Guid studioId)
        {
            var request = new LabelRequest(movieId, studioId);

            var response = await _labelService.GetSimpleLabel(request);
            return Ok(response);
        }

        /// <summary>
        /// Returnes a detailed label for a specific loan instance
        /// </summary>
        [HttpGet(ApiRoutes.Label.Detailed)]
        [Produces("application/xml")]
        public async Task<ActionResult<LabelDetailedResponse>> GetLabelDetailed([FromRoute]Guid movieId ,Guid studioId)
        {
            var request = new LabelRequest(movieId, studioId);
            
            var response = await _labelService.GetDetailedLabel(request);
            return Ok(response);
        }
    }
}