using SFFApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Requests
{
    public class MovieLoanRequest
    {
        public Movie Movie { get; set; }
        public Studio Studio { get; set; }
    }
}
