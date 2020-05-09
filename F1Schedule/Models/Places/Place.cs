using F1Schedule.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Models.Places
{
    public class Place
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Number")]
        [Required]
        [Range(1,20)]
        public int Number { get; set; }
        [Display(Name = "Points")]
        [Required]
        [Range(0,25)]
        [PointsDistribution]
        public int Points { get; set; }
    }
}
