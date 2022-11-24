using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class RoleAuthorityAddCommandRequest : IRequest<IReturnData<RoleAuthorityAddCommandResponse>>
    {
        public string Name { get; set; }
        public string RoleName { get; set; }
        public Guid RoleId { get; set; }
        public string AuthorityName { get; set; }
        public Guid AuthorityId { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
