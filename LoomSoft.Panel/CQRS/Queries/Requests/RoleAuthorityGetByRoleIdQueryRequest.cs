using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Queries.Requests
{
    public class RoleAuthorityGetByRoleIdQueryRequest : IRequest<IReturnData<RoleAuthorityGetByRoleIdQueryResponse>>
    {
        public Guid RoleId { get; set; }
    }
}
