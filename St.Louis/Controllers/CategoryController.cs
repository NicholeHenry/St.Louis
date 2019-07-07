using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using St.Louis.Data.Repositories;
using St.Louis.Models;
using St.Louis.ViewModels;
using St.Louis.ViewModels.Category;

namespace St.Louis.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Factory repositoryFactory;

        public CategoryController(Factory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            model.Persist(repositoryFactory);
            return RedirectToAction(controllerName: nameof(Location), actionName: nameof(Index));
        }
        
    }
}