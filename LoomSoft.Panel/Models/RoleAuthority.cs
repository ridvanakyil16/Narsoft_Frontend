namespace LoomSoft.Panel.Models
{
    public class RoleAuthority : BaseEntity
    {
        public string Name { get; set; }
        public string RoleName { get; set; }
        public Guid RoleId { get; set; }
        public string AuthorityName { get; set; }
        public Guid AuthorityId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Authority Authority { get; set; }
    }
}
