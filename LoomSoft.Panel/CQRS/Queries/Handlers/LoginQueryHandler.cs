using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, IReturnData<LoginQueryResponse>>
    {
        public async Task<IReturnData<LoginQueryResponse>> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<LoginQueryResponse> apiData = ApiRequest<LoginQueryResponse>.SendRequest("Auth/Login", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<LoginQueryResponse>()
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
