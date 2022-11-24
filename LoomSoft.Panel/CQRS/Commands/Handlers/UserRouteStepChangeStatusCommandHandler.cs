using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserRouteStepChangeStatusCommandHandler : IRequestHandler<UserRouteStepChangeStatusCommandRequest, IReturnData<UserRouteStepChangeStatusCommandResponse>>
    {
        public async Task<IReturnData<UserRouteStepChangeStatusCommandResponse>> Handle(UserRouteStepChangeStatusCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                IReturnData<UserRouteStepChangeStatusCommandResponse> apiData = ApiRequest<UserRouteStepChangeStatusCommandResponse>.SendRequest("Leave/UserRouteStepChangeStatus", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserRouteStepChangeStatusCommandResponse>()
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
