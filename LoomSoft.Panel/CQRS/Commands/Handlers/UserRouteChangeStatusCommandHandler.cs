using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserRouteChangeStatusCommandHandler : IRequestHandler<UserRouteChangeStatusCommandRequest, IReturnData<UserRouteChangeStatusCommandResponse>>
    {
        public async Task<IReturnData<UserRouteChangeStatusCommandResponse>> Handle(UserRouteChangeStatusCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserRouteChangeStatusCommandResponse> apiData = ApiRequest<UserRouteChangeStatusCommandResponse>.SendRequest("Leave/UserRouteChangeStatus", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserRouteChangeStatusCommandResponse>()
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
