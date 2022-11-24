using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class LeaveStepConcludeByLeaveIdCommandRequest : IRequest<IReturnData<LeaveStepConcludeByLeaveIdCommandResponse>>
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid LeaveId { get; set; }
        public int Result { get; set; }
        public string ResultNote { get; set; }
    }
}
