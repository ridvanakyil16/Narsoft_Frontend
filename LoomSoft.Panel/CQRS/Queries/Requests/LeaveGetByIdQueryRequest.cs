using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class LeaveGetByIdQueryRequest : IRequest<IReturnData<LeaveGetByIdQueryResponse>>
    {
        public Guid LeaveId { get; set; }
        public Guid UserId { get; set; }
    }
}
