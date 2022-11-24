using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class LoginQueryRequest : IRequest<IReturnData<LoginQueryResponse>>
    {
        public string RegistrationNumber { get; set; }
        public string Password { get; set; }
    }
}
