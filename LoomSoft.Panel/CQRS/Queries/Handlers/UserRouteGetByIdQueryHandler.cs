using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class UserRouteGetByIdQueryHandler : IRequestHandler<UserRouteGetByIdQueryRequest, IReturnData<UserRouteGetByIdQueryResponse>>
    {
        public async Task<IReturnData<UserRouteGetByIdQueryResponse>> Handle(UserRouteGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserRouteGetByIdQueryResponse> apiData = ApiRequest<UserRouteGetByIdQueryResponse>.SendRequest("Leave/UserRouteDetail", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserRouteGetByIdQueryResponse>()
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
