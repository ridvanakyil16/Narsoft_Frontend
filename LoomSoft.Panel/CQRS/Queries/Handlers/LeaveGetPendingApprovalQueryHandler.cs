using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class LeaveGetPendingApprovalQueryHandler : IRequestHandler<LeaveGetPendingApprovalQueryRequest, IReturnData<LeaveGetPendingApprovalQueryResponse>>
    {
        public async Task<IReturnData<LeaveGetPendingApprovalQueryResponse>> Handle(LeaveGetPendingApprovalQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<LeaveGetPendingApprovalQueryResponse> apiData = ApiRequest<LeaveGetPendingApprovalQueryResponse>.SendRequest("Leave/GetPendingApprovalLeaves", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<LeaveGetPendingApprovalQueryResponse>()
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
