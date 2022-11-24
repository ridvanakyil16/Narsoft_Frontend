using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;

namespace LoomSoft.Panel.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginControl([FromBody] LoginQueryRequest request)
        {
            IReturnData<LoginQueryResponse> user = _mediator.Send(request).Result;
            // return Json(user);

            if (user.Data.UserData == null)
            {
                return Json(new { aciklama = "Kullanıcı bulunamadı. Kullanıcı adı veya şifre hatalı!" });
            }
            else
            {
                UserCompanyGetByUserIdQueryRequest user2 = new UserCompanyGetByUserIdQueryRequest();
                user2.UserId = user.Data.UserData.Id;
                IReturnData<UserCompanyGetByUserIdQueryResponse> userCompanyList = _mediator.Send(user2).Result;

                if (userCompanyList.Data.UserCompanies == null)
                {
                    return Json(new { aciklama = "Kullanıcının şirketi Bulunmamaktadır." });
                }
                else
                {
                    user.Data.UserData.UserCompanies = userCompanyList.Data.UserCompanies;
                    return Json(new { aciklama = "UserCompany", user });
                }
            }
        }

        [HttpPost]
        public JsonResult Login([FromBody] LoginVerificationQueryRequest request)
        {
            IReturnData<LoginVerificationQueryResponse> user = _mediator.Send(request).Result;
            if (user.IsSuccess)
            {
                //return Json("Ok");
                bool cookieResult = SetCookie(user.Data.UserData);
                if (cookieResult)
                {
                    return Json("Ok");
                }
                else
                {
                    return Json("CookieError");
                }
            }
            else
            {
                return Json(user.StatusMessage);
            }
        }

        public bool SetCookie(User entity)
        {
            try
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.PrimarySid, entity.Id.ToString()),
                new Claim(ClaimTypes.PrimaryGroupSid,entity.UserCompanies[0].CompanyId.ToString()),
                new Claim(ClaimTypes.Locality, entity.UserCompanies[0].CompanyName.ToString()),
                new Claim(ClaimTypes.Name, entity.Name.ToUpper()),
                new Claim(ClaimTypes.Surname, entity.Surname.ToUpper()),
                new Claim(ClaimTypes.Actor, entity.RegistrationNumber)
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties { IsPersistent = true };
                _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
