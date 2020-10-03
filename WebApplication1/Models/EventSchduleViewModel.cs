using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EventSchduleViewModel
    {
        public int scheduleId;
        public string eventName;
        public string member;
        public string coach;

        public List<Schedule> Schedules;
        public List<Event> Events;
        public List<Member> Members;
    }
}
