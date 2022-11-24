using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserRouteAddCommandHandler : IRequestHandler<UserRouteAddCommandRequest, IReturnData<UserRouteAddCommandResponse>>
    {
        public async Task<IReturnData<UserRouteAddCommandResponse>> Handle(UserRouteAddCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserRouteAddCommandResponse> apiData = ApiRequest<UserRouteAddCommandResponse>.SendRequest("Leave/AddUserRoute", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserRouteAddCommandResponse>()
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
