using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museum.Models.Adapters
{
    public class ApplicationUserAdapter
    {
        public int ApplicationUser_ID { get; set; }
        public string? UserAvatar { get; set; }

        public string? UserName { get; set; }

        public string? NormalizedUserName { get; set; }

        public string? Email { get; set; }

        public string? NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string? PasswordHash { get; set; }

        public string? PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }
    }
}
