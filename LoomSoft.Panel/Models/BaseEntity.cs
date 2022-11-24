namespace LoomSoft.Panel.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedUserId { get; set; }
        public string? Note { get; set; }
        public int Status { get; set; }

        //public User CreatedUser { get; set; }
        //public User UpdatedUser { get; set; }
    }
}
