using ChefsAndDishes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ChefController : Controller
{
    // Adding a private variable of type MyContext
    private MyContext db;
    public ChefController(MyContext context)
    {
        db = context;
    }

    // Displaying the form for user to submit new chef
    [HttpGet("/chefs/new")]
    public IActionResult NewChef()
    {
        return View ("NewChef");
    }
    
    // Creating POST route then re-directing as data is being submitted
    [HttpPost("/chefs/create")]
    public IActionResult Create(Chef newChef)
    {
        if(!ModelState.IsValid)
        {
            Console.WriteLine("Validations did not pass for creating chefs.");
            return NewChef();
        }
        db.Chefs.Add(newChef);
        db.SaveChanges();

        Console.WriteLine(newChef.ChefId);
        return RedirectToAction("AllChefs");
    }

    [HttpGet("/chefs/all")]
    public IActionResult AllChefs()
    {
        // ViewBag.allChefs = db.Chefs.ToList();
        List<Chef> allChefs = db.Chefs.OrderBy(eachChef => eachChef.FirstName).ToList();
        // Utilizing viewbag to display cooked dishes list and retrieve count
        ViewBag.CookedDishes = db.Chefs.Include(eachDish => eachDish.CookedDishes).ToList();
        return View("AllChefs", allChefs);
    }
}
