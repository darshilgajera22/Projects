using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class ReleaseYearValidationAttribute : ValidationAttribute
{
    public ReleaseYearValidationAttribute()
    {
        ErrorMessage = "Release year should be 3 years old";
    }

    public override bool IsValid(object value)
    {
        if(value is int releaseYear)
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - releaseYear >= 3;
        }
        return false;
    }
}