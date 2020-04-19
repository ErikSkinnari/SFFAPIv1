using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class LoanInstance
    {
        public Movie Movie { get; set; }
        public Studio Studio { get; set; }
        public DateTime TimeOfLoan { get; set; }

    }
}
