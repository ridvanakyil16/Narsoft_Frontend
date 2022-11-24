using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class UserCompanyGetByUserIdQueryHandler : IRequestHandler<UserCompanyGetByUserIdQueryRequest, IReturnData<UserCompanyGetByUserIdQueryResponse>>
    {
        public async Task<IReturnData<UserCompanyGetByUserIdQueryResponse>> Handle(UserCompanyGetByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserCompanyGetByUserIdQueryResponse> apiData = ApiRequest<UserCompanyGetByUserIdQueryResponse>.SendRequest("User/GetUserCompanyList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserCompanyGetByUserIdQueryResponse>()
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
