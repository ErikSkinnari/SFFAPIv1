using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class MovieLibraryObject
    {
        public int Id { get; set; }
        public Guid MovieId { get; set; }
        public int Avaliable { get; set; }
        public int LicenseLimit { get; set; }
    }
}
