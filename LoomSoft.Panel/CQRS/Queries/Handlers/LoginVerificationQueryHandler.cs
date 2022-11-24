using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class LoginVerificationQueryHandler : IRequestHandler<LoginVerificationQueryRequest, IReturnData<LoginVerificationQueryResponse>>
    {
        public async Task<IReturnData<LoginVerificationQueryResponse>> Handle(LoginVerificationQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<LoginVerificationQueryResponse> apiData = ApiRequest<LoginVerificationQueryResponse>.SendRequest("Auth/LoginVerification", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<LoginVerificationQueryResponse>()
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
