using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class UserRoleGetByUserIdQueryHandler : IRequestHandler<UserRoleGetByUserIdQueryRequest, IReturnData<UserRoleGetByUserIdQueryResponse>>
    {
        public async Task<IReturnData<UserRoleGetByUserIdQueryResponse>> Handle(UserRoleGetByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserRoleGetByUserIdQueryResponse> apiData = ApiRequest<UserRoleGetByUserIdQueryResponse>.SendRequest("User/GetUserRoleList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserRoleGetByUserIdQueryResponse>()
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
