using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class MovieLoanInstance
    {
        public int Id { get; set; }
        public Guid MovieLoanInstanceId { get; set; }
        public bool Returned { get; set; } = false;

        public int MovieId { get; set; }
        public Movie Movie { get; set; }    

        public int StudioId { get; set; }
        public Studio Studio { get; set; }

        public DateTime TimeOfLoan { get; set; }
        public DateTime TimeOfReturn { get; set; } 
    }
}
