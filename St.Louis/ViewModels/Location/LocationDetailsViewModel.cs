using Microsoft.AspNetCore.Mvc.Rendering;
using St.Louis.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace St.Louis.ViewModels.Locations
{
    public class LocationDetailsViewModel

    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; }
        
        public List<string> Reviews { get; set; }

        /*public List<string> Categories GetCategoriesList()

        {

            return Factory.GetCategoryRepository()

                .GetModels()

                .Cast<Director>()

                .Select(director => GetDirectorListItemFromDirector(director))

                .ToList();

        }



        private static DirectorListItemViewModel GetDirectorListItemFromDirector(Director director)

        {

            return new DirectorListItemViewModel

            {

                Id = director.Id,

                FullName = director.FullName,

                BirthDate = director.BirthDate.ToShortDateString(),

                Nationality = director.Nationality

            };

        }*/



        public int Id { get; set; }

        public string FullName { get; set; }

        public string BirthDate { get; set; }

        public string Nationality { get; set; }

    }
}

