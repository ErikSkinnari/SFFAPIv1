using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class MoviePool
    {
        public int LicenseLimit { get; set; } // Sets the number limit of licensed loans.
        public string MovieId { get; set; }
        public Queue<Movie> Pool { get; set; }

        public MoviePool(string movieId, int licenseLimit)
        {
            MovieId = movieId;
            LicenseLimit = licenseLimit;
        }
    }
}
