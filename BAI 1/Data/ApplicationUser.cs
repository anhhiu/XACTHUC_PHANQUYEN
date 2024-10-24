﻿using Microsoft.AspNetCore.Identity;

namespace BAI_1.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
