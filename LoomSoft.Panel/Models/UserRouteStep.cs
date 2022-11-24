namespace LoomSoft.Panel.Models
{
    public class UserRouteStep : BaseEntity
    {
        public string Name { get; set; }
        public Guid UserRouteId { get; set; }
        public  Guid ApproverId { get; set; }
        public string ApproverName { get; set; }
        public Guid InformedId { get; set; }
        public string InformedName { get; set; }
        public int StepIndex { get; set; }

        public virtual User Approver { get; set; }
        public virtual User Informed { get; set; }
        public virtual UserRoute UserRoute { get; set; }
    }
}
