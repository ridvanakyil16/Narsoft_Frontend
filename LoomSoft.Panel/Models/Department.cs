namespace LoomSoft.Panel.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public virtual List<UserDepartment> UserDepartments { get; set; }
    }
}
