using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DateTime DateRegistration { get; set; }
        public DateTime DateChangePassword { get; set; }
        public DateTime LastEnterDateTime { get; set; }

        public bool IsEnabled { get; set; }
        public bool ChangePasswordOnNextEnter { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public IList<Permission> Permissions { get; set; }
    }
}
