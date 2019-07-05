using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace St.Louis.Models
{
    public class RateReview
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int LocationId { get; set; }
    }
}
