using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class UsersGetByCompanyIdQueryRequest : IRequest<IReturnData<UsersGetByCompanyIdQueryResponse>>
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
