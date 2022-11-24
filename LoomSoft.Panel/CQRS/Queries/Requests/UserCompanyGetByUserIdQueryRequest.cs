using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class UserCompanyGetByUserIdQueryRequest : IRequest<IReturnData<UserCompanyGetByUserIdQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
