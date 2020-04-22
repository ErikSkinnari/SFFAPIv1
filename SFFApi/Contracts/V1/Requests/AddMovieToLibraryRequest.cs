using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Requests
{
    public class AddMovieToLibraryRequest
    {
        public Guid MovieId { get; set; }
        public int LicenseLimit { get; set; }
    }
}
