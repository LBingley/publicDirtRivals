using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirtRivalsswag.Models;
using ExternalDAL;
using DirtRivalsswag;
using Microsoft.EntityFrameworkCore;

namespace testswagger.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class DailyController : ControllerBase
    {
        private DailyChallengeGetter DCG = new DailyChallengeGetter();
        private DailyEntriesGetter DEG = new DailyEntriesGetter();
        private IQueryable<Entry> removeEntries;
        private readonly DailyChallengeContext _context;
        public DailyController(DailyChallengeContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllDailys")]
        public MetaData getAll()
        {
            // MetaData md = new MetaData();
            List<MetaData> MetaDatas = new List<MetaData>();
            using (_context)
            {
                MetaDatas = _context.Metadatas.ToList();
                if(MetaDatas.Count < 1)
                {
                    MetaDatas.Add(DCG.getAllDailys());
                    _context.Metadatas.Add(MetaDatas[0]);
                    _context.SaveChanges();
                }
                MetaDatas[0].Challenges = _context.Challenges.ToList();

                
            }
            return MetaDatas[0];
        }
        [HttpGet]
        [Route("GetEntriesByName")]
        public List<Entry> GetEntries(string jsonName)
        {
            if (jsonName != null)
            {
                using (_context)
                {
                    List<Entry> newEntries = DEG.GetEntryByName(jsonName);

                    if (_context.Challenges.Single(c => c.ReferenceName == jsonName) != null)
                    {
                        Challenge challenge = _context.Challenges.Single(c => c.ReferenceName == jsonName);
                        //    if (challenge.entries == null) { challenge.entries = new List<Entry>(); }

                        removeEntries = _context.Entries.Where(e => e.ChallengeId == challenge.Id); //.ToList?

                        foreach (Entry entry in removeEntries)
                        {
                            _context.Entries.Remove(entry);
                        }

                        _context.SaveChanges();

                        challenge.Entries = newEntries;
                        _context.Challenges.Update(challenge);
                        _context.SaveChanges();

                        return challenge.Entries;
                    }
                    // unable to call saveChanges() on update that violates unique constraint temporarily

                    
                }
            }
            return null; //todo: return usefull http error code
        }

        [HttpGet]
        [Route("DeleteEntries")]
        public void deleteTest(string jsonName)
        {
            if (jsonName != null)
            {
                using (_context)
                {
                    List<Entry> newEntries = DEG.GetEntryByName(jsonName);
                    
                    if (_context.Challenges.Single(c => c.ReferenceName == jsonName) != null) 
                    {
                        Challenge challenge = _context.Challenges.Single(c => c.ReferenceName == jsonName);
                        //    if (challenge.entries == null) { challenge.entries = new List<Entry>(); }

                         removeEntries = _context.Entries.Where(e => e.ChallengeId == challenge.Id);
                        
                        foreach(Entry entry in removeEntries)
                        {
                            _context.Entries.Remove(entry);
                        }

                        _context.SaveChanges();
                    }

                    
                }
            }
        }


    }
}
