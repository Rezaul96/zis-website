using Domain.Common;
using Domain.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Member : BaseEntity<Guid>
    {
      
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Mobile { get; set; }
        [StringLength(150)]
        public string Password { get; set; }
        [StringLength(200)]
        public string Image { get; set; }
        public Roles Roles { get; set; }
        [StringLength(10)]
        public string OTP { get; set; }

        public string Name => FirstName + " " + LastName;
    }
}
