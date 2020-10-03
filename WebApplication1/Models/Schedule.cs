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
        //public ICollection<EventSchduleViewModel> EventSchduleViewModels { get; set; }
    }
}
