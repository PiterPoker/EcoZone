using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using Domain.Model;

namespace EcoZone.Models
{
    public class ChangeRoleViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            
        }
        public ChangeRoleViewModel(ApplicationUser user, IList<string> roles)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}