using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Contracts.V1.Requests
{
    public class UpdateMovieInLibrary
    {
        public Guid MovieObjectId { get; set; }
        public int LicenseLimit { get; set; }

    }
}
