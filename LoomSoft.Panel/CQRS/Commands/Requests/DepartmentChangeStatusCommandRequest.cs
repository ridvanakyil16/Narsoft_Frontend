using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class DepartmentChangeStatusCommandRequest : IRequest<IReturnData<DepartmentChangeStatusCommandResponse>>
    {
        public Guid DepartmentId { get; set; }
        public int Status { get; set; }
        public Guid UpdatedUserId { get; set; }
    }
}
