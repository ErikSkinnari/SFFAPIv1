using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Requests
{
    public class AddRatingRequest
    {
        public string MovieId { get; set; }
        public string StudioId { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
    }
}
