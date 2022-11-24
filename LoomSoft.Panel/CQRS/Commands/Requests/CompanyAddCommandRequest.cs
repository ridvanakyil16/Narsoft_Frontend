using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class CompanyAddCommandRequest : IRequest<IReturnData<CompanyAddCommandResponse>>
    {
        public string Name { get; set; }
        public string CompanyCode { get; set; }
        public int DepartmentType { get; set; }
        public string LogoName { get; set; }
        public string LogoString { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
