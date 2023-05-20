using ChefsAndDishes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DishController : Controller
{
    // Adding a private variable of type MyContext
    private MyContext db;
    public DishController(MyContext context)
    {
        db = context;
    }
    
    // Displaying the form for user to submit new chef
    [HttpGet("/dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.allChefs = db.Chefs.ToList();
        return View ("NewDish");
    }

    // Creating POST route then re-directing as data is being submitted
    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if(!ModelState.IsValid)
        {
            Console.WriteLine("Validations did not pass for creating chefs.");
            return NewDish();
        }
        db.Dishes.Add(newDish);
        db.SaveChanges();

        Console.WriteLine(newDish.ChefId);
        return RedirectToAction("AllDishes");
    }

    [HttpGet("/dishes/all")]
    public IActionResult AllDishes()
    {
        List<Dish> allDishes = db.Dishes.Include(eachDish => eachDish.Cuisinier).ToList();

        return View("AllDishes", allDishes);
    }
}