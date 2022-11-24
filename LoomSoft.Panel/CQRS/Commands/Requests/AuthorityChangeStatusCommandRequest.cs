using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class AuthorityChangeStatusCommandRequest : IRequest<IReturnData<AuthorityChangeStatusCommandResponse>>
    {
        public Guid AuthorityId { get; set; }
        public int Status { get; set; }
        public Guid UpdatedUserId { get; set; }
    }
}
