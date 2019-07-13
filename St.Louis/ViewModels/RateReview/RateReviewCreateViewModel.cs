using Microsoft.AspNetCore.Mvc.Rendering;
using St.Louis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using St.Louis.Models;
using St.Louis.Data.Repositories;

namespace St.Louis.ViewModels.RateReview
{
    public class RateReviewCreateViewModel
    {
        
        
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int LocationId { get; set; }
       
      public RateReviewCreateViewModel()
        {

        }
       public RateReviewCreateViewModel( Factory repositoryFactory)
        {

           
        }
   
         public void Persist(Factory repositoryFactory)
        {
            Models.RateReview rateReview = new Models.RateReview
            {
                LocationId = this.LocationId,
                Rating = this.Rating,
                Review = this.Review
            };
           repositoryFactory.GetRateReviewRepository().Save(rateReview);
        }

        
    }
}
