using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoomSoft.Panel.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DashboardController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Statistics()
        {
            return View();
        }
    }
}
