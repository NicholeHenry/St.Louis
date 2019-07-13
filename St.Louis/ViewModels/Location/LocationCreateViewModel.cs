using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using St.Louis.Data;
using St.Louis.Data.Repositories;
using St.Louis.Models;
using System.ComponentModel.DataAnnotations;

namespace St.Louis.ViewModels.Location
{
    public class LocationCreateViewModel
    {
        [Required (ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter a description")]
        [StringLength(200, MinimumLength = 2, ErrorMessage ="Please create a description between 2- 200 words")]
        public string Description { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Please choose a region")]
        public Region Region { get; set; }

       // public int CategoryId { get; set; }
       // public string CategoryName { get; set; }
       // public List<int> CategoryIds { get; set; }
       // public List<Models.Category> Categories { get; set; }

        public LocationCreateViewModel() { }

        public LocationCreateViewModel(Factory repositoryFactory) { }


        
        public void Persist(Factory repositoryFactory)
        {
            Models.Location location = new Models.Location
            {
                Name = this.Name,
                Description = this.Description,
                Address = this.Address,
                Region = this.Region,



            };
            repositoryFactory.GetLocationRepository().Save(location);


            

        }
       
    }   
}
