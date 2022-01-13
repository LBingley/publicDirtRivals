using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirtRivalsswag.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string EntryReferenceName { get; set; }
        public string DriverName { get; set; }
        public int Rank { get; set; }
        public string VehicleName { get; set; }
        public bool DNF { get; set; }
        public double stagetime { get; set; }
        public string Nationality { get; set; }
        public bool wheel { get; set; }
        public string platform { get; set; }
        public bool assist { get; set; }
        public int ChallengeId { get; set; }

        

    }
}
