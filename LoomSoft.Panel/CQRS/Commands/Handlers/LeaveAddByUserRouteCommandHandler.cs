using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class LeaveAddByUserRouteCommandHandler : IRequestHandler<LeaveAddByUserRouteCommandRequest, IReturnData<LeaveAddByUserRouteCommandResponse>>
    {
        public async Task<IReturnData<LeaveAddByUserRouteCommandResponse>> Handle(LeaveAddByUserRouteCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<LeaveAddByUserRouteCommandResponse> apiData = ApiRequest<LeaveAddByUserRouteCommandResponse>.SendRequest("Leave/AddLeaveByUserRoute", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<LeaveAddByUserRouteCommandResponse>()
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
