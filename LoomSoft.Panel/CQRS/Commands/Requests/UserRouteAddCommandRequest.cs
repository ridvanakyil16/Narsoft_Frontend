using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class UserRouteAddCommandRequest :IRequest<IReturnData<UserRouteAddCommandResponse>>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string RouteCode { get; set; }
        public int RouteType { get; set; } // 0 izin - 1 mesai //
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }

        public Guid CreatedUserId  { get; set; }
        public virtual List<UserRouteStepAddCommandRequest> UserRouteSteps { get; set; }
    }
}
