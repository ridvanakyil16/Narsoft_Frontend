using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class UserCompanyAddCommandRequest : IRequest<IReturnData<UserCompanyAddCommandResponse>>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
