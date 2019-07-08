using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using St.Louis.Models;
using St.Louis.Data.Repositories;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace St.Louis.ViewModels.Location
{
    public class LocationListViewModel


    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string AverageRating { get; set; }
        public string Description { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public List<int> Rating { get; set; }
        public List<string> Review { get; set; }
        



       public LocationListViewModel (Factory repositoryFactory)
        {
            this.AverageRating = GetAverageRating(repositoryFactory);
            this.Review = GetReviewsList(repositoryFactory);
        }

       public static List<LocationListViewModel> GetLocations(Factory repositoryFactory)
            {
                return repositoryFactory.GetLocationRepository()
                    .GetModels()
                    .Cast<Models.Location>()
                   
                    .Select(location => new LocationListViewModel(location))
                    .ToList();
            }

       private List<string> GetReviewsList(Factory repositoryFactory)
             {
                 return repositoryFactory.GetRateReviewRepository()
                     .GetModels()
                     .Where(r=> r.LocationId == Id)
                     .Select(r=>r.Review).ToList();
             }

       private string  GetAverageRating(Factory repositoryFactory)
         {
            return repositoryFactory.GetRateReviewRepository()
                .GetModels()
                .Where(r => r.LocationId == Id)
                .Select(r => r.Rating).Average().ToString();
         }
        

            public LocationListViewModel(Models.Location location)
            {
                this.Id = location.Id;
                this.Name = location.Name;
                this.AverageRating = //location.Ratings.Count > 0 ? Math.Round(location.Ratings.Average(x => x.Rating), 2).ToString() : "none";
                this.Description = location.Description;
               
            }

      
    }
}
