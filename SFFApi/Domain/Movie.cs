using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SFFApi.Domain
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public Guid MovieGuid { get; set; }
        public string Title { get; set; }

        public ICollection<Rating> Scores { get; set; }
    }
}
