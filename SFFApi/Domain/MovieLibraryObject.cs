using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class MovieLibraryObject
    {
        [Key]
        public int Id { get; set; }
        public Guid MovieId { get; set; }
        public int Avaliable { get; set; }
        public int LicenseLimit { get; set; }
    }
}
