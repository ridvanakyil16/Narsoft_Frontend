using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class LoginVerificationQueryRequest : IRequest<IReturnData<LoginVerificationQueryResponse>>
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Password { get; set; }
    }
}
