using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserRouteStepAddCommandHandler : IRequestHandler<UserRouteStepAddCommandRequest, IReturnData<UserRouteStepAddCommandResponse>>
    {
        public async Task<IReturnData<UserRouteStepAddCommandResponse>> Handle(UserRouteStepAddCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserRouteStepAddCommandResponse> apiData = ApiRequest<UserRouteStepAddCommandResponse>.SendRequest("Leave/AddUserRouteStep", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserRouteStepAddCommandResponse>()
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
