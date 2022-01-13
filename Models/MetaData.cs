using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirtRivalsswag.Models
{
    public class MetaData
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Year { get; set; }
        public List<Challenge> Challenges { get; set; } = new List<Challenge>();
    }
}
