using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Dob { get; set; }
        public Role RoleType { get; set; }
        public string Gender { get; set; }
        public string Biography { get; set; }

        public ICollection<Event> Events { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
