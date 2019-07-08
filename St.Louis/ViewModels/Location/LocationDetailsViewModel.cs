using Microsoft.AspNetCore.Mvc.Rendering;
using St.Louis.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using St.Louis.Models;

namespace St.Louis.ViewModels.Locations
{
    public class LocationDetailsViewModel

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       // public List<string> Categories { get; set; }
        
        public List<string> Reviews { get; set; }
        public List<int> Ratings { get; set; }

            
        

        public static List<LocationDetailsViewModel> GetLocationDetails(Factory repositoryFactory)
        {

            return repositoryFactory.GetLocationRepository()
            .GetModels()
            .Cast<Models.Location>()
            .Select(location => new LocationDetailsViewModel(location))
            .ToList();
        }
       

        private List<string> GetReviewsList(Factory repositoryFactory)
        {
            return repositoryFactory.GetRateReviewRepository()
                .GetModels()
                .Where(r => r.LocationId == Id)
                .Select(r => r.Review).ToList();
        }

        private List<int> GetRatingList(Factory repositoryFactory)
        {
            return repositoryFactory.GetRateReviewRepository()
                .GetModels()
                .Where(r => r.LocationId == Id)
                .Select(r => r.Rating).ToList();
        }

        public LocationDetailsViewModel(Models.Location location, Factory repositoryFactory )
        {
            this.Id = location.Id;
            this.Name = location.Name;
            this.Description = location.Description;
            this.Ratings = GetRatingList(repositoryFactory);
            this.Reviews = GetReviewsList(repositoryFactory);

        }

        public LocationDetailsViewModel(Models.Location location)
        {

        }


    }
}

