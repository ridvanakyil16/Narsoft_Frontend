using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;

namespace LoomSoft.Panel.CQRS.Commands.Requests
{
    public class UserAddCommandRequest : IRequest<IReturnData<UserAddCommandResponse>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int UserLevel { get; set; }
        public bool IsAdmin { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }

        public string PhotoName { get; set; }
        public string PhotoString { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
