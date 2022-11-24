namespace LoomSoft.Panel.Models
{
    public class UserDepartment : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
    }
}
