#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsAndDishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get; set;}

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must have at least 2 characters.")]
    [Display(Name = "First Name: ")]
    public string FirstName {get; set;}

    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must have at least 2 characters.")]
    [Display(Name = "Last Name: ")]
    public string LastName {get; set;}

    [NotMapped]
    public string? FullName {get; set;}

    [Required(ErrorMessage = "is required.")]
    [Display(Name = "Date of Birth: ")]
    // [DataType(DataType.Date)] 
        // this is also a different validator for the DateOfBirth DateTime type
    public DateTime DateOfBirth {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    // Navigation Property to track the total Dishes our Chef(s) have created and instantiating them
    public List<Dish> CookedDishes {get; set;} = new List<Dish>();

}