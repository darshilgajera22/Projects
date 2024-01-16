using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class PurchaseDateValidationAttribute : ValidationAttribute
{
    public PurchaseDateValidationAttribute()
    {
        ErrorMessage = "Purchase date should be in date format and it can not be in future";
    }

    public override bool IsValid(object value)
    {
        if (value is DateTime purchaseDate)
        {
            if(purchaseDate.TimeOfDay == TimeSpan.Zero)
            {
                if(purchaseDate.Date <= DateTime.Today)
                {
                    return true;
                }
            }
        }
        return false;
    }
}