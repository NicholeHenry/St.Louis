using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using St.Louis.Models;

namespace St.Louis.Data.Repositories
{
    public class Factory
    { 
        
        private  ApplicationDbContext context;

        public Factory(ApplicationDbContext context)
        {
            this.context = context;
        }

        public  IRepository<Location> GetLocationRepository()
        {
            return new BaseRepository<Location>(context);
        }

        public IRepository<RateReview> GetRateReviewRepository()
        {
            return new BaseRepository<RateReview>(context);
        }

        public IRepository<Category> GetCategoryRepository()
        {
            return new BaseRepository<Category>(context);
        }

        public IRepository<CategoryLocation> GetCategoryLocationRepository()
        {
            return new BaseRepository<CategoryLocation>(context);
        }
    }
}
