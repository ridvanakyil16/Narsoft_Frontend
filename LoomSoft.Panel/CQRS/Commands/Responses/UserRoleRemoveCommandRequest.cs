using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;


namespace LoomSoft.Panel.CQRS.Commands.Responses
{
    public class UserRoleRemoveCommandRequest : IRequest<IReturnData<UserRoleRemoveCommandResponse>>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public Guid UpdatedUserId { get; set; }
    }
}
