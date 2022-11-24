using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class DepartmentsGetByCompanyIdQueryHandler : IRequestHandler<DepartmentsGetByCompanyIdQueryRequest, IReturnData<DepartmentsGetByCompanyIdQueryResponse>>
    {
        public async Task<IReturnData<DepartmentsGetByCompanyIdQueryResponse>> Handle(DepartmentsGetByCompanyIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<DepartmentsGetByCompanyIdQueryResponse> apiData = ApiRequest<DepartmentsGetByCompanyIdQueryResponse>.SendRequest("User/GetDepartmentList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<DepartmentsGetByCompanyIdQueryResponse>()
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
