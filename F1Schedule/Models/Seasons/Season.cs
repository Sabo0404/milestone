using F1Schedule.Models.Teams;
using F1Schedule.Models.Races;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using F1Schedule.Models.SeasonRaces;

namespace F1Schedule.Models.Seasons
{
    public class Season
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Year")]
        [Required]
        [Range(1940,2030)]
        public int Year { get; set; }
        [Display(Name = "Teams")]
        public List<Team> Teams { get; set; }
        [Display(Name = "Races")]
        public List<SeasonRace> Races { get; set; }
    }
}
