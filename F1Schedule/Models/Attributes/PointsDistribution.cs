using F1Schedule.Models.Places;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Models.Attributes
{
    public class PointsDistribution : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var place = (Place)validationContext.ObjectInstance;
            var points = (int)value;

            if(place.Number < 4)
            {
                if (points > 9)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Podium placers must gain 10 or more points");

            }
            if (place.Number < 11 && place.Number > 3)
            {
                if (points > 0 && points < 11)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Midfield placers must gain 10 or less points");

            }
            if (place.Number > 10)
            {
                if (points == 0)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Last placers does not gain points");

            }
            return new ValidationResult("Value for 'points' must be between 0 and 25");

        }
    }
}
