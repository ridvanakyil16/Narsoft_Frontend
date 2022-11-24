using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Responses
{
    public class CompanyAddCommandResponse
    {
        public Company  CompanyData { get; set; }
    }
}
