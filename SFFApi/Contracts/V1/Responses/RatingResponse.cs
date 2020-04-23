using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Responses
{
    public class RatingResponse
    {
        public string MovieName { get; set; }
        public string StudioName { get; set; }
        public int Score  { get; set; }
    }
}
