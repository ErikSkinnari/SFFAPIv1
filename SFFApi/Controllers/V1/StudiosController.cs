using Microsoft.AspNetCore.Mvc;
using SFFApi.Contracts.V1;
using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Domain;
using SFFApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Controllers.V1
{
    public class StudiosController : Controller
    {
        private readonly IStudioService _studioService;

        public StudiosController(IStudioService studioService)
        {
            _studioService = studioService;
        }

        [HttpGet(ApiRoutes.Studios.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studioService.GetStudiosAsync());
        }

        [HttpGet(ApiRoutes.Studios.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid Id)
        {
            var response = await _studioService.GetStudioByIdAsync(Id);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPut(ApiRoutes.Studios.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid Id, UpdateStudioRequest request)
        {
            var oldStudio = await _studioService.GetStudioByIdAsync(Id);
            var studio = new Studio
            {
                StudioId = Id,
                Name = request.Name ?? oldStudio.Name,
                Address = new Address
                {
                    AddressLine1 = request.AddressLine1 ?? oldStudio.Address.AddressLine1,
                    AddressLine2 = request.AddressLine2 ?? oldStudio.Address.AddressLine2,
                    ZipCode = request.ZipCode ?? oldStudio.Address.ZipCode,
                    City = request.City ?? oldStudio.Address.City
                }
            };

            var updateSuccess = await _studioService.UpdateStudioAsync(studio);

            if (updateSuccess) 
                return Ok(studio);

            return NotFound();
        }
        
        [HttpDelete(ApiRoutes.Studios.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid Id)
        {
            var studioDeleted = await _studioService.DeleteStudioAsync(Id);
            if (studioDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost(ApiRoutes.Studios.Create)] // TODO Fix this method
        public async Task<IActionResult> Create([FromBody] CreateStudioRequest request)
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

            var success = await _studioService.AddStudioAsync(studio);
            if (!success)
            {
                return NotFound();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Movies.Get.Replace("{Id}", studio.StudioId.ToString());

            var response = new StudioResponse { StudioId = studio.StudioId, Name = studio.Name };

            return Created(locationUri, response);
        }
    }
}
