﻿using St.Louis.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using St.Louis.Models;
using St.Louis.Data;
using Microsoft.AspNetCore.Mvc;

namespace St.Louis.ViewModels.Locations
{
    public class LocationListViewModel
    {

        public static List<LocationListViewModel> GetLocations(Factory repositoryFactory)
        {
            return repositoryFactory.GetLocationRepository()
                .GetModels()
                .Cast<Location>()
                .Select(location => new LocationListViewModel(location))
                .ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AverageRating { get; set; }
        public string Description { get; set; }
       


        public LocationCreateViewModel(Location location)
        {
            this.Id = location.Id;
            this.Name = location.Name;
            this.AverageRating = location.Ratings.Count > 0 ? Math.Round(location.Ratings.Average(x => x.Rating), 2).ToString() : "none";
            this.Description = location.Description;
        }
    }
}
