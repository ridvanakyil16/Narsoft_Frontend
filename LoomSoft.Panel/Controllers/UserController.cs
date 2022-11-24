using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace LoomSoft.Panel.Controllers
{

    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }



        #region User

        [HttpGet]
        public IActionResult MyProfile()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            UserGetByIdQueryRequest userRequest = new UserGetByIdQueryRequest() { UserId = userId };
            var user = _mediator.Send(userRequest).Result.Data.UserData;
            return View(user);
        }

        [HttpGet]
        public IActionResult Users()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            UsersGetByCompanyIdQueryRequest request = new UsersGetByCompanyIdQueryRequest() { UserId = userId, CompanyId = companyId };
            return View(_mediator.Send(request).Result.Data);
        }

        public IActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UserAdd(UserAddCommandRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            var companyName = identity.FindFirst(ClaimTypes.Locality).Value.ToString();
            request.CreatedUserId = userId;
            request.CompanyId = companyId;
            request.CompanyName = companyName;
            request.PhotoName = "foto.jpg";
            request.PhotoString = "foto1";
            IReturnData<UserAddCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }


        [HttpPost]
        public JsonResult UserChangeStatus(UserChangeStatusCommandRequest request)
        {
            IReturnData<UserChangeStatusCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }

        [HttpPost]
        public JsonResult PasswordChange(PasswordChangeCommandRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            request.UserId = userId;
            IReturnData<PasswordChangeCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }


        #endregion

        #region Company
        [HttpGet]
        public IActionResult Companies()
        {
            CompanyGetAllQueryRequest request = new CompanyGetAllQueryRequest() { UserId = Guid.NewGuid() };
            return View(_mediator.Send(request).Result.Data);
        }

        public IActionResult CompanyAdd()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CompanyAdd(CompanyAddCommandRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            IReturnData<CompanyAddCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }

        [HttpPost]
        public JsonResult CompanyChangeStatus(CompanyChangeStatusCommandRequest request)
        {
            IReturnData<CompanyChangeStatusCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        #endregion

        #region Department
        [HttpGet]
        public IActionResult Departments()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            DepartmentsGetByCompanyIdQueryRequest request = new DepartmentsGetByCompanyIdQueryRequest() { UserId = userId, CompanyId = companyId };
            return View(_mediator.Send(request).Result.Data);
        }
        public IActionResult DepartmentAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepartmentAdd(DepartmentAddCommandRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            var companyName = identity.FindFirst(ClaimTypes.Locality).Value.ToString();
            request.CreatedUserId = userId;
            request.CompanyId = companyId;
            request.CompanyName = companyName;
            IReturnData<DepartmentAddCommandResponse> apiData = _mediator.Send(request).Result;
            return RedirectToAction("Departments");
        }
        [HttpPost]
        public JsonResult DepartmentChangeStatus(DepartmentChangeStatusCommandRequest request)
        {
            IReturnData<DepartmentChangeStatusCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        #endregion

        #region Role
        [HttpGet]
        public IActionResult Roles()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            RolesGetByCompanyIdQueryRequest request = new RolesGetByCompanyIdQueryRequest() { UserId = userId, CompanyId = companyId };
            return View(_mediator.Send(request).Result.Data);
        }
        public IActionResult RoleAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RoleAdd(RoleAddCommandRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            var companyName = identity.FindFirst(ClaimTypes.Locality).Value.ToString();
            request.CreatedUserId = userId;
            request.CompanyId = companyId;
            request.CompanyName = companyName;
            IReturnData<RoleAddCommandResponse> apiData = _mediator.Send(request).Result;
            return RedirectToAction("Roles");
        }
        [HttpPost]
        public JsonResult RoleChangeStatus(RoleChangeStatusCommandRequest request)
        {
            IReturnData<RoleChangeStatusCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        #endregion

        #region Authority
        [HttpGet]
        public IActionResult Authorities()
        {
            AuthorityGetAllQueryRequest request = new AuthorityGetAllQueryRequest() { UserId = Guid.NewGuid() };
            return View(_mediator.Send(request).Result.Data);
        }
        public IActionResult AuthorityAdd()
        {
            var identity = (ClaimsIdentity)User.Identity;
            Guid userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            AuthorityGetAllQueryRequest request = new AuthorityGetAllQueryRequest() { UserId = userId };
            List<Authority> authorities = _mediator.Send(request).Result.Data.Authorities.Where(x => x.AuthorityType == 0).ToList();
            return View(authorities);
        }

        [HttpPost]
        public JsonResult AuthorityAdd(AuthorityAddCommandRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            Guid userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            request.CreatedUserId = userId;
            IReturnData<AuthorityAddCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        [HttpPost]
        public JsonResult AuthorityChangeStatus(AuthorityChangeStatusCommandRequest request)
        {
            IReturnData<AuthorityChangeStatusCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        #endregion


        #region UserCompany
        [HttpGet]
        public IActionResult UserCompanies()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            CompanyGetAllQueryRequest companyRequest = new CompanyGetAllQueryRequest() { UserId = Guid.NewGuid() };
            ViewBag.Companies = _mediator.Send(companyRequest).Result.Data.Companies.Where(x => x.Status == 1).OrderBy(x => x.Name).ToList();
            UsersGetByCompanyIdQueryRequest userRequest = new UsersGetByCompanyIdQueryRequest() { UserId = userId, CompanyId = companyId };
            ViewBag.Users = _mediator.Send(userRequest).Result.Data.Users.Where(x => x.Status == 1).OrderBy(x => x.Name).ToList();
            return View();
        }

        [HttpPost]
        public JsonResult UserCompaniesByUserId(UserCompanyGetByUserIdQueryRequest request)
        {
            IReturnData<UserCompanyGetByUserIdQueryResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        [HttpPost]
        public JsonResult AddUserCompany(UserCompanyAddCommandRequest request)
        {
            IReturnData<UserCompanyAddCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        [HttpPost]
        public JsonResult DeleteUserCompany(UserCompanyRemoveCommandRequest request)
        {
            IReturnData<UserCompanyRemoveCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        #endregion

        #region UserDepartment
        [HttpGet]
        public IActionResult UserDepartments()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            DepartmentsGetByCompanyIdQueryRequest DepartmentRequest = new DepartmentsGetByCompanyIdQueryRequest() { UserId = userId, CompanyId = companyId };
            ViewBag.Departments = _mediator.Send(DepartmentRequest).Result.Data.Departments.Where(x=>x.Status==1).OrderBy(x=>x.Name).ToList();
            UsersGetByCompanyIdQueryRequest userRequest = new UsersGetByCompanyIdQueryRequest() { UserId = userId , CompanyId = companyId };
            ViewBag.Users = _mediator.Send(userRequest).Result.Data.Users.Where(x => x.Status == 1).OrderBy(x => x.Name).ToList();
            return View();
        }

        [HttpPost]
        public JsonResult UserDepartmentsByUserId(UserDepartmentsGetByCompanyIdQueryRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            request.CompanyId = companyId;
            IReturnData<UserDepartmentsGetByCompanyIdQueryResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        [HttpPost]
        public JsonResult AdduserDepartment(UserDepartmentAddCommandRequest request)
        {
            IReturnData<UserDepartmentAddCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        [HttpPost]
        public JsonResult DeleteuserDepartment(UserDepartmentRemoveCommandRequest request)
        {
            IReturnData<UserDepartmentRemoveCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        #endregion

        #region UserRole

        [HttpGet]
        public IActionResult UserRoles()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            RolesGetByCompanyIdQueryRequest roleRequest = new RolesGetByCompanyIdQueryRequest() { UserId = userId, CompanyId = companyId };
            ViewBag.Roles = _mediator.Send(roleRequest).Result.Data.Roles.Where(x=>x.Status==1).OrderBy(x=>x.Name).ToList();
            UsersGetByCompanyIdQueryRequest userRequest = new UsersGetByCompanyIdQueryRequest() { UserId = userId, CompanyId = companyId };
            ViewBag.Users = _mediator.Send(userRequest).Result.Data.Users.Where(x=>x.Status==1).OrderBy(x=>x.Name).ThenBy(x=>x.Surname).ToList();
            return View();
        }

        [HttpPost]
        public JsonResult UserRolesByUserId(UserRolesGetByCompanyIdQueryRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            request.CompanyId = companyId;
            IReturnData<UserRolesGetByCompanyIdQueryResponse> UserRoles = _mediator.Send(request).Result;
            return Json(UserRoles);
        }

        [HttpPost]
        public JsonResult AddUserRole(UserRoleAddCommandRequest request)
        {
            IReturnData<UserRoleAddCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }

        [HttpPost]
        public JsonResult DeleteUserRole(UserRoleRemoveCommandRequest request)
        {
            IReturnData<UserRoleRemoveCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }


        #endregion

        #region RoleAuthority
        [HttpGet]
        public IActionResult RoleAuthorities()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            var companyId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimaryGroupSid).Value.ToString());
            RolesGetByCompanyIdQueryRequest roleRequest = new RolesGetByCompanyIdQueryRequest() { UserId = userId, CompanyId = companyId };
            ViewBag.Roles = _mediator.Send(roleRequest).Result.Data.Roles.Where(x=>x.Status==1).OrderBy(x=>x.Name).ToList();
            AuthorityGetAllQueryRequest authorityRequest = new AuthorityGetAllQueryRequest() { UserId = Guid.NewGuid() };
            var authorities = _mediator.Send(authorityRequest).Result.Data.Authorities.Where(w => w.AuthorityType == 1 && w.Status==1).OrderBy(x=>x.Name).ToList();
            ViewBag.Authorities = authorities;
            return View();
        }


        [HttpPost]
        public JsonResult RoleAuthorityByRoleId(RoleAuthorityGetByRoleIdQueryRequest request)
        {
            IReturnData<RoleAuthorityGetByRoleIdQueryResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }


        [HttpPost]
        public JsonResult AddRoleAuthority(RoleAuthorityAddCommandRequest request)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(identity.FindFirst(ClaimTypes.PrimarySid).Value.ToString());
            request.CreatedUserId = userId; 
            IReturnData<RoleAuthorityAddCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }

        [HttpPost]
        public JsonResult DeleteRoleAuthority(RoleAuthorityRemoveCommandRequest request)
        {
            IReturnData<RoleAuthorityRemoveCommandResponse> apiData = _mediator.Send(request).Result;
            return Json(apiData);
        }
        #endregion


    }
}
