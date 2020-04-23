using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Requests
{
    public class AddTriviaRequest
    {
        public string MovieGuid { get; set; }
        public string StudioGuid { get; set; }
        public string TriviaText { get; set; }
    }
}
