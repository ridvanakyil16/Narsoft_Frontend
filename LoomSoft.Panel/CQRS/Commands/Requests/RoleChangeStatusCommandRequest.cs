using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class RoleChangeStatusCommandRequest : IRequest<IReturnData<RoleChangeStatusCommandResponse>>
    {
        public Guid RoleId { get; set; }
        public int Status { get; set; }
        public Guid UpdatedUserId { get; set; }
    }
}
