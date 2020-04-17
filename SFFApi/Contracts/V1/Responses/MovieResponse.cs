using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Responses
{
    public class MovieResponse
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }

    }
}
