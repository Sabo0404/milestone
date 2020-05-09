using F1Schedule.Models.SeasonRaces;
using F1Schedule.Models.Seasons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Models.Races
{
    public class Race
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Country")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Country { get; set; }
        [Display(Name = "DateTime")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        [Display(Name = "Seasons")]
        public List<SeasonRace> Seasons { get; set; }
    }
}
