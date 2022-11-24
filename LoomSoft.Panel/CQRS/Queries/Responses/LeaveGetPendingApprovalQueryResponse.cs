using LoomSoft.Panel.Models;

namespace LoomSoft.Panel.CQRS.Queries.Responses
{
    public class LeaveGetPendingApprovalQueryResponse
    {
        public List<Leave> Leaves { get; set; }
    }
}
