using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class RolesGetByCompanyIdQueryHandler : IRequestHandler<RolesGetByCompanyIdQueryRequest, IReturnData<RolesGetByCompanyIdQueryResponse>>
    {
        public async Task<IReturnData<RolesGetByCompanyIdQueryResponse>> Handle(RolesGetByCompanyIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<RolesGetByCompanyIdQueryResponse> apiData = ApiRequest<RolesGetByCompanyIdQueryResponse>.SendRequest("User/GetRoleList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<RolesGetByCompanyIdQueryResponse>()
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
