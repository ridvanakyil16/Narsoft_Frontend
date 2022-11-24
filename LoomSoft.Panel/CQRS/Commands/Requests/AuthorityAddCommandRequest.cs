using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class AuthorityAddCommandRequest : IRequest<IReturnData<AuthorityAddCommandResponse>>
    {
        public string Name { get; set; }
        public int Platform { get; set; }
        public int AuthorityType { get; set; }
        public int DepthLevel { get; set; }
        public Guid? MainAuthorityId { get; set; }
        public string? MainAuthorityName { get; set; }
        public int TabIndex { get; set; }
        public string? Link { get; set; }
        public string? MenuIcon { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
