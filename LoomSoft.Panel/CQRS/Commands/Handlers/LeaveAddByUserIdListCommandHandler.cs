using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class LeaveAddByUserIdListCommandHandler : IRequestHandler<LeaveAddByUserIdListCommandRequest, IReturnData<LeaveAddByUserIdListCommandResponse>>
    {
        public async Task<IReturnData<LeaveAddByUserIdListCommandResponse>> Handle(LeaveAddByUserIdListCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<LeaveAddByUserIdListCommandResponse> apiData = ApiRequest<LeaveAddByUserIdListCommandResponse>.SendRequest("Leave/AddLeaveByUserIdList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<LeaveAddByUserIdListCommandResponse>()
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
