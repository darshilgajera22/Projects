using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class GenreValidationAttribute : ValidationAttribute
{
    private readonly string[] validGenres = { "Action", "Driving", "FPS" };

    public GenreValidationAttribute()
    {
        ErrorMessage = "Please enter valid genre. Allowed genres are Action, Driving, FPS.";
    }

    public override bool IsValid(object value)
    {
        if (value is string genre)
        {
            if(!validGenres.Contains(genre)) 
            {
                return false; 
            }
        }
        return true;
    }
}
