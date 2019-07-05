using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace St.Louis.Models
{
    public class Location :IModel
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<RateReview> Ratings { get; set; }
        public virtual List<RateReview> Reviews { get; set; }
       
        public virtual List<CategoryLocation> CategoryLocations { get; set; }
        public string Address { get; set; }
        public Region Region { get; set; }
       



    }
}
