using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class LeaveGetAllQueryHandler : IRequestHandler<LeaveGetAllQueryRequest, IReturnData<LeaveGetAllQueryResponse>>
    {
        public async Task<IReturnData<LeaveGetAllQueryResponse>> Handle(LeaveGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<LeaveGetAllQueryResponse> apiData = ApiRequest<LeaveGetAllQueryResponse>.SendRequest("Leave/GetPendingApprovalLeaves", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<LeaveGetAllQueryResponse>()
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
