﻿using Microsoft.AspNetCore.Identity;

namespace TieTheKnot.Data
{

    public class ApplicationUser : IdentityUser
    {
        public string ? Name { get; set; }
        public string ? ProfilePicture { get; set; }



    }
}
