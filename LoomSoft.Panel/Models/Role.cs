namespace LoomSoft.Panel.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }



        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<RoleAuthority> RoleAuthorities { get; set; }
    }
}
