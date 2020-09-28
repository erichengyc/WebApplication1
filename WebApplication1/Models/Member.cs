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
        public DateTime Dob { get; set; }
        public Role RoleType { get; set; }
        public string Gender { get; set; }
    }
}
