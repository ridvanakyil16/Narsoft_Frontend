using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Responses
{
    public class UserDepartmentRemoveCommandResponse
    {
        public UserDepartment UserDepartmentData { get; set; }
    }
}
