using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class Trivia
    {
        [Key]
        public int Id { get; set; }
        public Guid TriviaGuid { get; set; }
        public string TriviaText { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; }
    }
}
