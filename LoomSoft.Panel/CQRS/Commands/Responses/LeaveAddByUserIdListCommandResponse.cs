using LoomSoft.Panel.Models;

namespace LoomSoft.Panel.CQRS.Commands.Responses
{
    public class LeaveAddByUserIdListCommandResponse
    {
        public List<Leave> Leaves { get; set; }
    }
}
