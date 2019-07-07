using Microsoft.AspNetCore.Mvc.Rendering;
using St.Louis.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace St.Louis.ViewModels.RateReview
{
    public class RateReviewCreateViewModel
    {
        private string ratings = "12345";
        private readonly Factory repositoryFactory;

        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int LocationId { get; set; }
        public SelectList Ratings { get { return GetRatings(); } }
       
        public RateReviewCreateViewModel (Factory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        private SelectList GetRatings()
        {
            var ratingNumbers = ratings.Select(r => new SelectListItem(r.ToString(), r.ToString()));
            return new SelectList(ratingNumbers);
        }

        internal void Persist()
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
