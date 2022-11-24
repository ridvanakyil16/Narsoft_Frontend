using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class AuthorityGetAllQueryRequest : IRequest<IReturnData<AuthorityGetAllQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
