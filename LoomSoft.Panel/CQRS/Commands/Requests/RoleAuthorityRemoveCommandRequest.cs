using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class RoleAuthorityRemoveCommandRequest : IRequest<IReturnData<RoleAuthorityRemoveCommandResponse>>
    {
        public Guid RoleId { get; set; }
        public Guid AuthorityId { get; set; }
        public Guid UpdatedUserId { get; set; }
    }
}
