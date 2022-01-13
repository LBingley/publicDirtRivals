using DirtRivalsswag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExternalDAL
{
    public class DailyEntriesGetter
    {
        public List<Entry> GetEntryByName(string jsonName)
        {
            List<Entry> entries = new List<Entry>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.chrisraff.com");
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.GetAsync("dirtrally2-event-data/daily/2020/"+ jsonName).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    Root root = JsonSerializer.Deserialize<Root>(responseString);
                    foreach(var file in root.entries)
                    {
                        entries.Add(new Entry { EntryReferenceName = jsonName,DriverName = file.name, Rank = file.rank, VehicleName = file.vehicleName, DNF = file.dnf , stagetime = file.stageTime, Nationality = file.nationality, wheel = file.wheel, platform = file.platform, assist = file.assist  });
                    }
                    return entries;
                }
            }

            return null; //custom exception?
        }

        internal class File
        {
            public int rank { get; set; }
            public string name { get; set; }
            public string vehicleName { get; set; }
            public bool dnf { get; set; }
            public double stageTime { get; set; }
            public double totalTime { get; set; }
            public string nationality { get; set; }
            public bool wheel { get; set; }
            public string platform { get; set; }
            public bool assist { get; set; }
        }

        internal class Root
        {
            public List<File> entries { get; set; }
        }
    }
}
