using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Responses
{
    public class DepartmentAddCommandResponse
    {
        public Department DepartmentData { get; set; }
    }
}
