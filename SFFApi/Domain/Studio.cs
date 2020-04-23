using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class Studio
    {
        [Key]
        public int Id { get; set; }
        public Guid StudioGuid { get; set; }
        public string Name { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
