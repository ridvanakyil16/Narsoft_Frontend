using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class UserRouteGetByIdQueryRequest : IRequest<IReturnData<UserRouteGetByIdQueryResponse>>
    {
        public Guid UserId { get; set; }
        public Guid UserRouteId { get; set; }
    }
}
