using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirtRivalsswag.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public string ChallengeName { get; set; }
        public string vehicleClass { get; set; }
        public DateTime entryWindowStart { get; set; }
        public DateTime entryWindowEnd { get; set; }
        public string eventName { get; set; }
        public string discipline { get; set; }
        public string stageName { get; set; }
        public string country { get; set; }
        public string location { get; set; }
        public string ReferenceName { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
