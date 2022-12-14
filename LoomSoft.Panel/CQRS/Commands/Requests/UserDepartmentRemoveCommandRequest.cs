using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class UserDepartmentRemoveCommandRequest : IRequest<IReturnData<UserDepartmentRemoveCommandResponse>>
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid UpdatedUserId { get; set; }
    }
}
