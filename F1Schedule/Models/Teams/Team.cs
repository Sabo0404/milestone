using F1Schedule.Models.Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Models.Teams
{
    public class Team
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Country")]
        [Required]
        [StringLength(30,MinimumLength = 3)]
        public string Country { get; set; }
        [Display(Name = "Drivers")]
        public List<Driver> Drivers { get; set; }
    }
}
