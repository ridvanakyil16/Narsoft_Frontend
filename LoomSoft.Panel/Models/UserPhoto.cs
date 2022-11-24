namespace LoomSoft.Panel.Models
{
    public class UserPhoto : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string PhotoString { get; set; }

        public virtual User User { get; set; }
    }
}
