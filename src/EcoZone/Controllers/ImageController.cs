using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcoZone.Controllers
{
    [Authorize]
    [Route("api/image")]
    public class ImageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ImageController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
    }
}