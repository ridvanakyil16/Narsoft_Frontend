using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class UserRoleGetByUserIdQueryRequest : IRequest<IReturnData<UserRoleGetByUserIdQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
