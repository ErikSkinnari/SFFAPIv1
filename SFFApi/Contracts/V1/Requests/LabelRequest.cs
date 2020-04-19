using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Requests
{
    public class LabelRequest
    {
        public Guid MovieId { get; set; }
        public Guid StudioId { get; set; }
    }
}
