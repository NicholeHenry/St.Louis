using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using St.Louis.Data.Repositories;
using St.Louis.ViewModels;
using St.Louis.ViewModels.Location;


namespace St.Louis.Controllers
{
    public class LocationController : Controller
    {
        private Factory repositoryFactory;

        public LocationController(Factory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }
        public IActionResult Index()
        {
            List<LocationListViewModel> location = LocationListViewModel.GetLocations( repositoryFactory);
            return View(location);
        }

       /* [HttpGet]
        public IActionResult Create()
        {
           // LocationCreateViewModel model = new LocationCreateViewModel(repositoryFactory);
           // return View(model);
        }*/

        [HttpPost]
        public IActionResult Create(LocationCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            model.Persist(repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}