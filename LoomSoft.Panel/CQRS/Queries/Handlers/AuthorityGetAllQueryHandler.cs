using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class AuthorityGetAllQueryHandler : IRequestHandler<AuthorityGetAllQueryRequest, IReturnData<AuthorityGetAllQueryResponse>>
    {
        public async Task<IReturnData<AuthorityGetAllQueryResponse>> Handle(AuthorityGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<AuthorityGetAllQueryResponse> apiData = ApiRequest<AuthorityGetAllQueryResponse>.SendRequest("User/GetAllAuthorityList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<AuthorityGetAllQueryResponse>()
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
