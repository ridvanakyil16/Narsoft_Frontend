namespace LoomSoft.Panel.Models
{
    public class LeaveStep : BaseEntity
    {
        public string Name { get; set; }
        public Guid LeaveId { get; set; }
        public Guid? ApproverId { get; set; }
        public string? ApproverName { get; set; }
        public Guid? InformedId { get; set; }
        public string? InformedName { get; set; }
        public int StepIndex { get; set; }
        public int Situation { get; set; }
        public int? Result { get; set; }
        public string? ResultNote { get; set; }


        public virtual User Approver { get; set; }
        public virtual User Informed { get; set; }
        public virtual Leave Leave { get; set; }
    }
}
