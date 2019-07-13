using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using St.Louis.Data.Repositories;
using St.Louis.Models;
using St.Louis.ViewModels.RateReview;

namespace St.Louis.Controllers
{
    public class RateReviewController : Controller
    { 
        public  Factory repositoryFactory;

        public RateReviewController(Factory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }
    
       [HttpGet]
       public IActionResult Create(int locationId)
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(int locationId, RateReviewCreateViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            model.Persist(repositoryFactory);
            return RedirectToAction(controllerName: nameof(Location), actionName: nameof(Index));
        }
    }
}