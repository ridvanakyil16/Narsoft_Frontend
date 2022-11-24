using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class CompanyChangeStatusCommandRequest : IRequest<IReturnData<CompanyChangeStatusCommandResponse>>
    {
        public Guid CompanyId { get; set; }
        public int Status { get; set; }
        public Guid UpdatedUserId { get; set; }
    }
}
