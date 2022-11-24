using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class PasswordChangeCommandRequest : IRequest<IReturnData<PasswordChangeCommandResponse>>
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
    }
}
