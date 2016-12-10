﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoType { get; set; }
        public List<Like> Likes { get; set; }
        public List<Unit> Units { get; set; }
        public List<Comment> Comments { get; set; }
    }
}