using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class UserRouteChangeStatusCommandRequest :IRequest<IReturnData<UserRouteChangeStatusCommandResponse>>
    {
        public Guid UserRouteId { get; set; }
        public int Status { get; set; }
        public Guid CreatedUserId { get; set; }   
    }
}
