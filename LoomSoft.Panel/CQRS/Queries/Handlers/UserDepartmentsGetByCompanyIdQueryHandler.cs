using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class UserDepartmentsGetByCompanyIdQueryHandler : IRequestHandler<UserDepartmentsGetByCompanyIdQueryRequest, IReturnData<UserDepartmentsGetByCompanyIdQueryResponse>>
    {
        public async Task<IReturnData<UserDepartmentsGetByCompanyIdQueryResponse>> Handle(UserDepartmentsGetByCompanyIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserDepartmentsGetByCompanyIdQueryResponse> apiData = ApiRequest<UserDepartmentsGetByCompanyIdQueryResponse>.SendRequest("User/GetUserDepartmentList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserDepartmentsGetByCompanyIdQueryResponse>()
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
