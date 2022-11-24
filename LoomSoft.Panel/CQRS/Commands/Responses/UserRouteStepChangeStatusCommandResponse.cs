using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;


namespace LoomSoft.Panel.CQRS.Commands.Responses
{
    public class UserRouteStepChangeStatusCommandResponse
    {
        public UserRouteStep UserRouteStepData { get; set; }
    }
}
