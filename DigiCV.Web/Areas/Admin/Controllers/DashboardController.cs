using DigiCV.Persistence.Features.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigiCV.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminManager")]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ILogger<DashboardController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> UsersRoles()
        {
            var users = await _userManager.Users.ToListAsync();
            IList<(string, string, string)> info = new List<(string, string email, string claim)>();

            foreach (var user in users)
            {
                var userClaims = await _userManager.GetClaimsAsync(user);

                var claims = "";
                foreach (var claim in userClaims)
                    claims += claim.Value + " ";

                info.Add((user.Id.ToString(), user.Email, claims));
            }

            return View(info);
        }
    }
}
