namespace LoomSoft.Panel.Models
{
    public class UserCompany : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }


        public virtual User User { get; set; }
        public virtual Company Company { get; set; }
    }
}
