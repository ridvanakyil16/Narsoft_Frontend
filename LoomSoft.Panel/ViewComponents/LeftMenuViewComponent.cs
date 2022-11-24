using LoomSoft.Panel.CQRS.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoomSoft.Panel.ViewComponents
{
    public class LeftMenuViewComponent :  ViewComponent
    {
        private readonly IMediator _mediator;
        public LeftMenuViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IViewComponentResult Invoke()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
                var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
                UserMenuListQueryRequest userRequest = new UserMenuListQueryRequest() { UserId = userId,CompanyId=companyId };
                var aa = _mediator.Send(userRequest).Result;
                var mainMenu = _mediator.Send(userRequest).Result.Data.MenuList;
                ViewBag.mainMenuList = mainMenu;
                return View(mainMenu);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
