using SFFApi.Contracts.V1.Requests;
using SFFApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Services
{
    public interface ILabelService
    {
        Task<ILabel> GetSimpleLabel(LabelRequest request);
        Task<ILabel> GetDetailedLable(LabelRequest request);
    }
}
