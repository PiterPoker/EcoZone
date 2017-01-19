using System.Threading.Tasks;
using Domain.Model;
using EcoZone.Models.ManageViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcoZone.Controllers
{
    [Authorize]
    [Route("api/profile")]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{id?}")]
        public async Task<object> Profile(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var currentUser = await _userManager.GetUserAsync(User);
                return new ProfileViewModel(currentUser, await _userManager.GetRolesAsync(currentUser));
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return "Not found";
            return new ProfileViewModel(user, await _userManager.GetRolesAsync(user));
        }
    }
}