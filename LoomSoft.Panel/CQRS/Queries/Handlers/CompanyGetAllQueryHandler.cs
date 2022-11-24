using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class CompanyGetAllQueryHandler : IRequestHandler<CompanyGetAllQueryRequest, IReturnData<CompanyGetAllQueryResponse>>
    {
        public async Task<IReturnData<CompanyGetAllQueryResponse>> Handle(CompanyGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<CompanyGetAllQueryResponse> apiData = ApiRequest<CompanyGetAllQueryResponse>.SendRequest("User/GetAllCompanyList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<CompanyGetAllQueryResponse>()
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
