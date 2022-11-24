using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class UserMenuListQueryHandler : IRequestHandler<UserMenuListQueryRequest, IReturnData<UserMenuListQueryResponse>>
    {
        public async Task<IReturnData<UserMenuListQueryResponse>> Handle(UserMenuListQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserMenuListQueryResponse> apiData = ApiRequest<UserMenuListQueryResponse>.SendRequest("Auth/UserMenuList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserMenuListQueryResponse>()
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
