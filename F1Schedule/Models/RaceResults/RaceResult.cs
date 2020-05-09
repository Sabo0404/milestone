using F1Schedule.Models.Drivers;
using F1Schedule.Models.Places;
using F1Schedule.Models.Races;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Models.RaceResults
{
    public class RaceResult
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Driver")]
        public Driver Driver { get; set; }
        [Display(Name = "Race")]
        public Race Race { get; set; }
        [Display(Name = "Place")]
        public Place Place { get; set; }
        [Display(Name = "Time")]
        [Required]
        [DataType(DataType.Time)]
        public float Time { get; set; }
    }
}
