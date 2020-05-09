using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using F1Schedule.Models.Cars;

namespace F1Schedule.Models.Drivers
{
    public class Driver : IValidatableObject
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Car")]
        public Car Car { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int wordCount = 1;

            for(int i = 0; i < Name.Length; i++)
            {
                if (Name[i] == ' ')
                    wordCount++;
            }
            if (wordCount != 2)
                yield return new ValidationResult("Input 'Name' must have last name and first name");
        }
    }
}
