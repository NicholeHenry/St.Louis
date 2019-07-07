using St.Louis.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using St.Louis.Models;

namespace St.Louis.ViewModels.Category
{
    public class CategoryCreateViewModel
    {
        public string CategoryName { get; set; }

        public void Persist(Factory repositoryFactory)
        {
            Models.Category category = new Models.Category
            {
                CategoryName = this.CategoryName
            };
            repositoryFactory.GetCategoryRepository().Save(category);


        }
    }
}
