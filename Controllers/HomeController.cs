using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CruDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CruDelicious.Controllers
{
    public class HomeController : Controller
    {
        private DishesContext dbContext;
        public HomeController(DishesContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.ToList();
            return View("Index", AllDishes);
        }

        [HttpGet]
        [Route("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("createdish")]
        public IActionResult CreateDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index", newDish);
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet]
        [Route("{dishId}")]
        public IActionResult DishPage(int dishId)
        {
            Dish dish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            return View("DishPage", dish);
        }

        [HttpGet]
        [Route("delete/{dishId}")]
        public IActionResult Delete(int dishId)
        {
            Dish dish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
            dbContext.Dishes.Remove(dish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{dishId}")]
        public IActionResult EditPage(int dishId)
        {
            Dish dish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);

            return View("EditPage", dish);
        }

        [HttpPost]
        [Route("edit/submit")]
        public IActionResult EditDish(int dishId, string Name, string Chef, int Calories, int Tastiness, string Description)
        {
            if (ModelState.IsValid)
            {
                Dish dish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishId);
                dish.Name = Name;
                dish.Chef = Chef;
                dish.Calories = Calories;
                dish.Tastiness = Tastiness;
                dish.Description = Description;
                dish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("DishPage", dish);
            }
            else
            {
                return View("EditPage");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
