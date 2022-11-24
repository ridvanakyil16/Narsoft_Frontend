using LoomSoft.Panel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace LoomSoft.Panel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            if (!identity.IsAuthenticated || string.IsNullOrEmpty(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString()))
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                return RedirectToAction("Statistics", "Dashboard");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}