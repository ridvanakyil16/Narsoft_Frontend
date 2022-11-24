using LoomSoft.Panel.Models;

namespace LoomSoft.Panel.CQRS.Queries.Responses
{
    public class UserRolesGetByCompanyIdQueryResponse
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
