using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class RoleAuthorityGetByRoleIdQueryHandler : IRequestHandler<RoleAuthorityGetByRoleIdQueryRequest, IReturnData<RoleAuthorityGetByRoleIdQueryResponse>>
    {
        public async Task<IReturnData<RoleAuthorityGetByRoleIdQueryResponse>> Handle(RoleAuthorityGetByRoleIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<RoleAuthorityGetByRoleIdQueryResponse> apiData = ApiRequest<RoleAuthorityGetByRoleIdQueryResponse>.SendRequest("User/GetRoleAuthorityList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<RoleAuthorityGetByRoleIdQueryResponse>()
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
