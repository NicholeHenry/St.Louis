using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace St.Louis.Models
{
    public class Category: IModel
    {

        public int Id { get; set; }
        public string CategoryName { get; set; }
        
        public virtual List<CategoryLocation> CategoryLocations { get; set; }
    }
}
