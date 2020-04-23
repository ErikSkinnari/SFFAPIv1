using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Domain
{
    public class MovieLoanInstance
    {
        [Key]
        public int Id { get; set; }
        public Guid MovieLoanInstanceGuid { get; set; }
        public bool IsReturned { get; set; } = false;

        public int MovieId { get; set; }
        public Movie Movie { get; set; }    

        public int StudioId { get; set; }
        public Studio Studio { get; set; }

        public DateTime TimeOfLoan { get; set; }
        public DateTime TimeOfReturn { get; set; } 
    }
}
