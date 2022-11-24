using LoomSoft.Panel.Models;

namespace LoomSoft.Panel.CQRS.Queries.Responses
{
    public class DepartmentsGetByCompanyIdQueryResponse
    {
        public List<Department> Departments { get; set; }
    }
}
