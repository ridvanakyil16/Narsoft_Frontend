namespace LoomSoft.Panel.Models
{
    public class CompanyLogo : BaseEntity
    {
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LogoString { get; set; }

        public virtual Company Company { get; set; }
    }
}
