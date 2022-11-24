using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;

namespace LoomSoft.Panel.Controllers
{
    public class LeaveController : Controller
    {
        private readonly IMediator _mediator;
        public LeaveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region UserRouteSettings

        [HttpGet]
        public IActionResult UserRouteSettings()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            UserRoutesGetByCompanyIdQueryRequest userRequest = new UserRoutesGetByCompanyIdQueryRequest() { UserId = userId, CompanyId = companyId };
            List<UserRoute> userRoutes = _mediator.Send(userRequest).Result.Data.UserRoutes;
            return View(userRoutes);
        }

        [HttpGet]
        public IActionResult UserRouteDetails(Guid id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            UserRouteGetByIdQueryRequest request = new UserRouteGetByIdQueryRequest() { UserId = userId, UserRouteId = id };
            return View(_mediator.Send(request).Result.Data);
        }
        [HttpGet]
        public IActionResult AddUserRoute()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            UsersGetByCompanyIdQueryRequest userRequest = new UsersGetByCompanyIdQueryRequest() { UserId = userId, CompanyId = companyId };
            ViewBag.Users = _mediator.Send(userRequest).Result.Data.Users;
            return View();
        }
        [HttpPost]
        public JsonResult AddUserRoute(UserRouteAddCommandRequest request)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
                var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
                var companyName = identity.FindFirst(ClaimTypes.Locality).Value.ToString();

                request.CompanyId = companyId;
                request.CompanyName = companyName;
                request.CreatedUserId = userId;
                request.RouteCode = "RT";
                IReturnData<UserRouteAddCommandResponse> apiData = _mediator.Send(request).Result;

                return Json(apiData);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        [HttpPost]
        public JsonResult UserRouteChangeStatus(UserRouteChangeStatusCommandRequest request)
        {
            IReturnData<UserRouteChangeStatusCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }

        #endregion

        [HttpGet]
        public IActionResult RouteLeaveDefinition()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var registrationNumber = identity.FindFirst(ClaimTypes.Actor).Value.ToString();
            ViewBag.RegistrationNumber = registrationNumber;
            return View();
        }

        [HttpPost]
        public JsonResult LeaveAddByUserRoute(LeaveAddByUserRouteCommandRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            request.UserId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            request.CompanyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            request.CompanyName = identity.FindFirst(ClaimTypes.Locality).Value.ToString();
            request.UserName = identity.FindFirst(ClaimTypes.Name).Value.ToString() + " " + identity.FindFirst(ClaimTypes.Surname).Value.ToString();
            request.Name = request.UserName;
            request.CreatedUserId = request.UserId;
            return Json(_mediator.Send(request).Result);
        }

        [HttpGet]
        public IActionResult LeaveDetail(Guid id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            Guid userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            LeaveGetByIdQueryRequest request = new LeaveGetByIdQueryRequest() { LeaveId = id, UserId = userId };
            var response = _mediator.Send(request).Result.Data;
            return View(_mediator.Send(request).Result.Data);
        }

        [HttpGet]
        public IActionResult MultipleLeaveDefinition()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            UsersGetByCompanyIdQueryRequest userRequest = new UsersGetByCompanyIdQueryRequest() { UserId = userId, CompanyId= companyId };
            ViewBag.Users = _mediator.Send(userRequest).Result.Data.Users;
            return View();
        }


        public JsonResult AddLeaveByUserIdList(LeaveAddByUserIdListCommandRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            request.CompanyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            request.CompanyName = identity.FindFirst(ClaimTypes.Locality).Value.ToString();
            request.CreatedUserId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            request.Name = "Toplu İzin";
            return Json(_mediator.Send(request).Result);
        }

        [HttpGet]
        public IActionResult PendingApprovals()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            LeaveGetPendingApprovalQueryRequest userRequest = new LeaveGetPendingApprovalQueryRequest() { UserId = userId, CompanyId = companyId };
            LeaveGetPendingApprovalQueryResponse leaves = _mediator.Send(userRequest).Result.Data;
            return View(leaves);
        }

        [HttpPost]
        public JsonResult ConcludeLeave(LeaveStepConcludeByLeaveIdCommandRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            request.UserId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            request.CompanyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            return Json(_mediator.Send(request).Result);
        }
    }
}
