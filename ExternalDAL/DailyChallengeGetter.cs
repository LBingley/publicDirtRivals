using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using DirtRivalsswag.Models;

namespace ExternalDAL
{
    public class DailyChallengeGetter
    {
        public MetaData getAllDailys()
        {
            MetaData md = new MetaData();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.chrisraff.com");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("dirtrally2-event-data/daily/2020/info.json").Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    Root root =
                    JsonSerializer.Deserialize<Root>(responseString);
                    md.Category = root.category;
                    md.Year = root.year;
                    foreach (var file in root.files)
                    {
                        md.Challenges.Add(new Challenge {ChallengeName = file.challengeName, vehicleClass = file.vehicleClass, entryWindowStart = file.entryWindow.start, entryWindowEnd = file.entryWindow.close, eventName = file.eventName, discipline = file.discipline, country = file.country, location = file.location, ReferenceName = file.name, stageName = file.stageName });
                    }
                    return md;
                }
                
            }
            return null; //custom exception?
        }
        internal class EntryWindow
        {
            public DateTime start { get; set; }
            public DateTime close { get; set; }
        }

        internal class File
        {
            public int challengeId { get; set; }
            public int eventId { get; set; }
            public int stageId { get; set; }
            public string challengeName { get; set; }
            public string vehicleClass { get; set; }
            public EntryWindow entryWindow { get; set; }
            public bool isDirtPlus { get; set; }
            public int seasonNumber { get; set; }
            public string eventName { get; set; }
            public string discipline { get; set; }
            public string stageName { get; set; }
            public string country { get; set; }
            public string location { get; set; }
            public string challengeType { get; set; }
            public string name { get; set; }
        }

        internal class Root
        {
            public string category { get; set; }
            public string year { get; set; }
            public List<File> files { get; set; }
        }

    }
}
