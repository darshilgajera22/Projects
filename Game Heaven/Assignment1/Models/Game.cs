using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class Game
{
    [Key]
    public int GameId { get; set; }

    
    [Required(ErrorMessage = "Game title required")]
    public string Title { get; set; }

    
    [Required(ErrorMessage = "Developer name required")]
    public string Developer { get; set; }

    
    [Required(ErrorMessage = "Genre is required.")]
    [GenreValidation]
    public string Genre { get; set; }

    
    [Required(ErrorMessage = "Release date required")]
    [Display(Name = "Release Date")]
    [ReleaseYearValidation]
    public int ReleaseYear { get; set; }

    
    [Required(ErrorMessage = "Purchase date required")]
    [Display(Name = "Purchase Date")]
    [PurchaseDateValidation]
    [DataType(DataType.Date)]
    public DateTime? PurchaseDate { get; set; }

    
    [Range(1, 10, ErrorMessage = "Please enter between 1 to 10")]
    public int Rating { get; set; }
    
    

}
