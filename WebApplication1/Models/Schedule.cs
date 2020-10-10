using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }



        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        public int? EventId { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }
        public int MemberId { get; set; }
    }
}
