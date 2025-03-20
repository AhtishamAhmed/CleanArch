using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

}
