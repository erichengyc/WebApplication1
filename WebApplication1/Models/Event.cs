using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int MemberId { get; set; }


        public DateTime Date { get; set; }

        public Member Member { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
