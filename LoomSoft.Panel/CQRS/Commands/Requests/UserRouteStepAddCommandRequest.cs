using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class UserRouteStepAddCommandRequest :IRequest<IReturnData<UserRouteStepAddCommandResponse>>
    {
        public string Name { get; set; }
        public Guid UserRouteId { get; set; }
        public Guid ApproverId { get; set; }
        public string ApproverName { get; set; }
        public Guid InformedId { get; set; }
        public string InformedName { get; set; }
        public int StepIndex { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
