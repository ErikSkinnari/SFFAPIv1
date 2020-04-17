using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public Guid MovieId { get; set; }
        public string Title { get; set; }
    }
}
