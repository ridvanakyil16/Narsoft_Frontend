using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserRoleRemoveCommandHandler : IRequestHandler<UserRoleRemoveCommandRequest, IReturnData<UserRoleRemoveCommandResponse>>
    {
        public async Task<IReturnData<UserRoleRemoveCommandResponse>> Handle(UserRoleRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserRoleRemoveCommandResponse> apiData = ApiRequest<UserRoleRemoveCommandResponse>.SendRequest("User/RemoveUserRole", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserRoleRemoveCommandResponse>()
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
