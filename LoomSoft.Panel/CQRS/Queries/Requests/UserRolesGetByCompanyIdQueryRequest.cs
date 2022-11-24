using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class UserRolesGetByCompanyIdQueryRequest : IRequest<IReturnData<UserRolesGetByCompanyIdQueryResponse>>
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
