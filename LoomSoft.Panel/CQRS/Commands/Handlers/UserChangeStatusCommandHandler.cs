using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserChangeStatusCommandHandler : IRequestHandler<UserChangeStatusCommandRequest, IReturnData<UserChangeStatusCommandResponse>>
    {
        public async Task<IReturnData<UserChangeStatusCommandResponse>> Handle(UserChangeStatusCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserChangeStatusCommandResponse> apiData = ApiRequest<UserChangeStatusCommandResponse>.SendRequest("User/UserChangeStatus", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserChangeStatusCommandResponse>()
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
