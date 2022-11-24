using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class LeaveGetByIdQueryHandler : IRequestHandler<LeaveGetByIdQueryRequest, IReturnData<LeaveGetByIdQueryResponse>>
    {
        public async Task<IReturnData<LeaveGetByIdQueryResponse>> Handle(LeaveGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<LeaveGetByIdQueryResponse> apiData = ApiRequest<LeaveGetByIdQueryResponse>.SendRequest("Leave/GetLeaveDetail", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<LeaveGetByIdQueryResponse>()
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
