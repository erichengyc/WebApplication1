using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public partial class Member
    {
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Nickname is required.")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime Dob { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Biography is required.")]
        public string Biography { get; set; }

        public ICollection<Event> Events { get; set; }
        public ICollection<Schedule> Schedules { get; set; }

    }
}
