using System.Collections.Generic;
using Domain.Model;

namespace EcoZone.Models
{
    public class UsersViewModel
    {
        public UsersViewModel()
        {
        }

        public UsersViewModel(ApplicationUser user, IList<string> roles)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Photo = user.PhotoPath;
            Roles = roles;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public IList<string> Roles { get; set; }
    }
}