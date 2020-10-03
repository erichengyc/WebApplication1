using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public Event Event { get; set; }
        public Member Member { get; set; }
        public int EventId { get; internal set; }
        public int MemberId { get; internal set; }
        //public ICollection<EventSchduleViewModel> EventSchduleViewModels { get; set; }
    }
}
