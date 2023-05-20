using System.ComponentModel.DataAnnotations;
namespace ChefsAndDishes.Models;
#pragma warning disable CS8618

public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Name of Dish")]
    public string Name { get; set; }

    [Required(ErrorMessage = "is must be greater than 0.")]
    public int Calories { get; set; }

    [Required(ErrorMessage = " rating must be between 1 and 5.")]
    public int Tastiness { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
 
    // Foreign Key that connects to our Chef table 
    public int ChefId {get; set;}

    // Cuisinier is related to each Dish
    public Chef? Cuisinier {get; set;}
}