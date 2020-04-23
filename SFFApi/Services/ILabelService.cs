using SFFApi.Contracts.V1.Requests;
using SFFApi.Contracts.V1.Responses;
using SFFApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Services
{
    public interface ILabelService
    {
        Task<EtikettData> GetSimpleLabel(Guid loanId);
        Task<LabelDetailedResponse> GetDetailedLabel(Guid loanId);
    }
}
