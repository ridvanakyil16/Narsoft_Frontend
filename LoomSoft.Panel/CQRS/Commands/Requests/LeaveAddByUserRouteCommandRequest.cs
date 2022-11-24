using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class LeaveAddByUserRouteCommandRequest : IRequest<IReturnData<LeaveAddByUserRouteCommandResponse>>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int LeaveType { get; set; }
        public string Reason { get; set; }
        public int TimeType { get; set; }
        public int RangeType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
