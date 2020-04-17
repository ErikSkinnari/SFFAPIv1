using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class Studio
    {
        public int Id { get; set; }
        public Guid StudioId { get; set; }
        public string Name { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
