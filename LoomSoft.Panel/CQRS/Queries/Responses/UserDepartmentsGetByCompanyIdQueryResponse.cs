using LoomSoft.Panel.Models;

namespace LoomSoft.Panel.CQRS.Queries.Responses
{
    public class UserDepartmentsGetByCompanyIdQueryResponse
    {
        public List<UserDepartment> UserDepartments { get; set; }
    }
}
