using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> ErrorMessages { get; set; }

    }
}
