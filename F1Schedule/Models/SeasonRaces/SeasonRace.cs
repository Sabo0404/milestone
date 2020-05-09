using F1Schedule.Models.Races;
using F1Schedule.Models.Seasons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F1Schedule.Models.SeasonRaces
{
    public class SeasonRace
    {
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
    }
}
