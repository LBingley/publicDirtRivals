using DirtRivalsswag.Models;
using ExternalDAL;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirtRivalsswag.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class RivalController : ControllerBase
        {
            // private DailyChallengeGetter DCG = new DailyChallengeGetter();
            private DailyEntriesGetter DEG = new DailyEntriesGetter();
            private readonly DailyChallengeContext _context;
            public RivalController(DailyChallengeContext context)
            {
                _context = context;
            }
        [HttpGet]
        [Route("GetAllRivals")] // Not by name yet
        public List<Rival> getAll()
        {

            List<Rival> rivals = new List<Rival>();
           
                rivals = _context.Rivals.ToList();


            
            return rivals;
        }
        [HttpPost]
        [Route("PostRival")]
        public void postRival(string driverName)// void still returns http codes. very mature.
        {
            Rival rival = new Rival { DriverName = driverName };
            using (_context)
            {
                _context.Rivals.Add(rival);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetAllRivalsEntries")]
        public IEnumerable<Entry> GetAllRivalsEntries()
        {
            List<Rival> rivals = this.getAll();
            List<Entry> rivalentries = new List<Entry>();
            using (_context)
            {
                foreach (Rival rival in rivals)
                {

                    List<Entry> tempRivalEntries = _context.Entries.Where(e => e.DriverName == rival.DriverName).ToList();
                    foreach (Entry tempRivalEntry in tempRivalEntries)
                    {
                        rivalentries.Add(tempRivalEntry);
                    }
                }
            }
            // List<Entry> distinctEntries = new List<Entry>();
            // distinctEntries.Add((Entry)rivalentries.Distinct());
            return rivalentries.Distinct();
            
        }

    }
}
