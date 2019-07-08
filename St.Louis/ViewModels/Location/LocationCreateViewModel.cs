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
        public List<int> CategoryIds { get; set; }
        public List<Models.Category> Categories { get; set; }

        public LocationCreateViewModel() { }


        public LocationCreateViewModel(Factory repositoryFactory)
         {
            this.Categories = repositoryFactory.GetCategoryRepository()
                .GetModels()
                .Cast<Models.Category>()
                .ToList();
                


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


            List<CategoryLocation> categoryLocations = CreateManyToManyRelationships(location.Id);

            location.CategoryLocations = categoryLocations;

            repositoryFactory.GetCategoryLocationRepository().Save(LocationId);
        }

        private List<CategoryLocation> CreateManyToManyRelationships(int locationId)
        {
            return CategoryIds.Select(categoryId => new CategoryLocation { LocationId = locationId, CategoryId = categoryId }).ToList();
        }



       
    }   
}
