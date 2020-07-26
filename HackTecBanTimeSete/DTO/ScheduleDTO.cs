using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.DTO
{


    public class SessionScheduleDTO
    {
        public string Name { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string Location { get; set; }
        public List<string> Tracks { get; set; }
        public string Id { get; set; }

    }

    public class GroupsScheduleDTO
    {
        public string Time { get; set; }
        public IList<SessionScheduleDTO> Sessions { get; set; }

    }

    public class ScheduleDTO
    {
        public string Date { get; set; }
        public IList<GroupsScheduleDTO> Groups { get; set; }

    }


}
