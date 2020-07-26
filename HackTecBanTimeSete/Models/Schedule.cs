using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    public class Track
    {
        public int TrackId { get; set; }
        public string track { get; set; }
    }

    public class SessionSchedule
    {
        public int SessionScheduleId { get; set; }
        public string Name { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string Location { get; set; }
        public List<Track> Tracks { get; set; } // TEM Q CRIAR O DTO
        public string Id { get; set; }

    }

    public class GroupsSchedule
    {
        public int GroupsScheduleId { get; set; }
        public string Time { get; set; }
        public IList<SessionSchedule> Sessions { get; set; }

    }

    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string Date { get; set; }
        public IList<GroupsSchedule> Groups { get; set; }

    }

}
