using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Responses
{
    public class AuthorityAddCommandResponse
    {
        public Authority AuthorityData { get; set; }
    }
}
