namespace LoomSoft.Panel.Models
{
    public class Authority : BaseEntity
    {
        public string Name { get; set; }
        public int Platform { get; set; }
        public int AuthorityType { get; set; }
        public int DepthLevel { get; set; }
        public Guid? MainAuthorityId { get; set; }
        public string? MainAuthorityName { get; set; }
        public int TabIndex { get; set; }
        public string? Link { get; set; }
        public string? MenuIcon { get; set; }


        public virtual Authority MainAuthority { get; set; }
        public virtual List<Authority> SubAuthorities { get; set; }
        public List<RoleAuthority> RoleAuthorities { get; set; }
    }
}
