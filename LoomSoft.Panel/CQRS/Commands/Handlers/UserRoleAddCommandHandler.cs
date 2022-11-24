using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using LoomSoft.Panel.Models;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserRoleAddCommandHandler : IRequestHandler<UserRoleAddCommandRequest, IReturnData<UserRoleAddCommandResponse>>
    {
        public async Task<IReturnData<UserRoleAddCommandResponse>> Handle(UserRoleAddCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserRoleAddCommandResponse> apiData = ApiRequest<UserRoleAddCommandResponse>.SendRequest("User/AddUserRole", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserRoleAddCommandResponse>()
                {
                    Data = null,
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.MethodNotAllowed,
                    StatusMessage = "Handler hatası. Lütfen tekrar deneyiniz.",
                    ExMessage = ex.Message
                };
            }

        }
    }
}
