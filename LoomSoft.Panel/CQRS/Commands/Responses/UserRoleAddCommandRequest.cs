using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Responses
{
    public class UserRoleAddCommandRequest : IRequest<IReturnData<UserRoleAddCommandResponse>>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
