using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Models.Cars
{
    public class Car
    {
        [Display(Name="Id")]
        public int Id { get; set; }
        [Display(Name = "Number")]
        [Required]
        [Range(0,99)]
        public int Number { get; set; }
        [Required]
        [Remote("VerifyHPLimit", controller: "Cars", AdditionalFields = nameof(mguHP))]
        public int engineHP { get; set; }
        [Required]
        [Remote("VerifyHPLimit", controller: "Cars", AdditionalFields = nameof(engineHP))]
        public int mguHP { get; set; }
    }
}
