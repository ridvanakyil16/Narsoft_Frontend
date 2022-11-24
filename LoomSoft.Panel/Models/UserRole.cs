namespace LoomSoft.Panel.Models
{
    public class UserRole : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }


        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
