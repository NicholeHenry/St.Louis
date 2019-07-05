using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using St.Louis.Data;
using St.Louis.Data.Repositories;
using St.Louis.Models;

namespace St.Louis.ViewModels
{
    public class LocationCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Region Region { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable <SelectListItem> Categories { get; set; }

        public LocationCreateViewModel() { }

        public  LocationCreateViewModel(Factory repositoryFactory)
        {
            this.Categories = GetCategoriesList(repositoryFactory);
        }

        public LocationCreateViewModel(List<Category> categories)
        {
            this.Categories = Categories;
        }

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
        private IEnumerable<SelectListItem> GetCategoriesList(Factory repositoryFactory)
        {
            return repositoryFactory.GetCategoryRepository()
                .GetModels()
                .Select(c => new SelectListItem(c.CategoryName, c.Id.ToString(), c.Id == this.CategoryId));
        }
        
    }
}
