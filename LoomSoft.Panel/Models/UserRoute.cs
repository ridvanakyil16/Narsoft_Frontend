namespace LoomSoft.Panel.Models
{
    public class UserRoute : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string RouteCode { get; set; }
        public int RouteNumber { get; set; }
        public int RouteType { get; set; } // 0 izin - 1 mesai
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }


        public Company Company { get; set; }
        public virtual User User { get; set; }
        public virtual List<UserRouteStep> UserRouteSteps { get; set; }
    }
}
