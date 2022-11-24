using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class CompanyGetAllQueryRequest : IRequest<IReturnData<CompanyGetAllQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
