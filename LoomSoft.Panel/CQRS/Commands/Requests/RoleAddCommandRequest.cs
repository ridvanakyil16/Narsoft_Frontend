using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class RoleAddCommandRequest : IRequest<IReturnData<RoleAddCommandResponse>>
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
