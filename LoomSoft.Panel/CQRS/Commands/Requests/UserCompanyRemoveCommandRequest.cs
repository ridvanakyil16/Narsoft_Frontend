using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class UserCompanyRemoveCommandRequest : IRequest<IReturnData<UserCompanyRemoveCommandResponse>>
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid UpdatedUserId { get; set; }
    }
}
