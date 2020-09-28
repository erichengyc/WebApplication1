using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public Event EventId { get; set; }
        public Member MemberId { get; set; }
    }
}
