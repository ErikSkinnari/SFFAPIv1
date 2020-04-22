using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Services
{
    public interface ILabelService
    {
        Task<EtikettData> GetSimpleLabel(LabelRequest request);
        Task<LabelDetailedResponse> GetDetailedLabel(LabelRequest request);
    }
}
