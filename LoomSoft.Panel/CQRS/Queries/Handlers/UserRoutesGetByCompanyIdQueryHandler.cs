using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class UserRoutesGetByCompanyIdQueryHandler : IRequestHandler<UserRoutesGetByCompanyIdQueryRequest, IReturnData<UserRoutesGetByCompanyIdQueryResponse>>
    {
        public async Task<IReturnData<UserRoutesGetByCompanyIdQueryResponse>> Handle(UserRoutesGetByCompanyIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserRoutesGetByCompanyIdQueryResponse> apiData = ApiRequest<UserRoutesGetByCompanyIdQueryResponse>.SendRequest("Leave/GetUserRouteList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserRoutesGetByCompanyIdQueryResponse>()
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
