using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoPath { get; set; }
        public bool IsApproved { get; set; } = false;
        public List<Like> Likes { get; set; }
        public List<Unit> Units { get; set; }
        public List<Comment> Comments { get; set; }
    }
}