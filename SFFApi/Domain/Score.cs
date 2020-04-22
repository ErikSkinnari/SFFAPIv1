using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class Score
    {
        public int Id { get; set; }

        [Range(1,5, ErrorMessage = "Score must be between 1 and 5")]
        public int Rating { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
