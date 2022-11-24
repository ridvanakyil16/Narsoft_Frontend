using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class UserRolesGetByCompanyIdQueryHandler : IRequestHandler<UserRolesGetByCompanyIdQueryRequest, IReturnData<UserRolesGetByCompanyIdQueryResponse>>
    {
        public async Task<IReturnData<UserRolesGetByCompanyIdQueryResponse>> Handle(UserRolesGetByCompanyIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserRolesGetByCompanyIdQueryResponse> apiData = ApiRequest<UserRolesGetByCompanyIdQueryResponse>.SendRequest("User/GetUserRoleList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserRolesGetByCompanyIdQueryResponse>()
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
