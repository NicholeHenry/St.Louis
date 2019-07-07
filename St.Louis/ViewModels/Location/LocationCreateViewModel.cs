using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using St.Louis.Data;
using St.Louis.Data.Repositories;
using St.Louis.Models;

namespace St.Louis.ViewModels.Location
{
    public class LocationCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Region Region { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        // public bool CheckboxAnswer { get; set; }

        public List<int> CategoryIds { get; set; }
        public List<Category> Categories { get; set; }

        public LocationCreateViewModel() { }
        /* public LocationCreateViewModel(Factory repositoryFactory)
         {
             this.Categories = repositoryFactory.GetCategoryRepository();
         }*/
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
