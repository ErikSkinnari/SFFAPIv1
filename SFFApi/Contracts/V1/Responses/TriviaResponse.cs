using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Responses
{
    public class TriviaResponse
    {
        public string MovieTitle { get; set; }
        public string TriviaText { get; set; }
    }
}
