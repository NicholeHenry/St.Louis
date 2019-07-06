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
        

           /* public static List<LocationListViewModel> GetLocations()
            {
                return Factory.GetLocationRepository()
                    .GetModels()
                    .Cast<Models.Location>()
                    .Select(location => new LocationListViewModel(location))
                    .ToList();
            }*/

            public int Id { get; set; }
            public string Name { get; set; }
            public string AverageRating { get; set; }
            public string Description { get; set; }
            public IEnumerable<SelectListItem> Categories { get; set; }
            public IEnumerable<SelectListItem> Ratings { get; set; }
            public IEnumerable<SelectListItem> Review { get; set; }
        

            public LocationListViewModel(Models.Location location)
            {
                this.Id = location.Id;
                this.Name = location.Name;
                this.AverageRating = location.Ratings.Count > 0 ? Math.Round(location.Ratings.Average(x => x.Rating), 2).ToString() : "none";
                this.Description = location.Description;
            }
        
    }
}
