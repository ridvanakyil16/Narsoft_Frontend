using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class UsersGetByCompanyIdQueryHandler : IRequestHandler<UsersGetByCompanyIdQueryRequest, IReturnData<UsersGetByCompanyIdQueryResponse>>
    {
        public async Task<IReturnData<UsersGetByCompanyIdQueryResponse>> Handle(UsersGetByCompanyIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UsersGetByCompanyIdQueryResponse> apiData = ApiRequest<UsersGetByCompanyIdQueryResponse>.SendRequest("User/GetUserList", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UsersGetByCompanyIdQueryResponse>()
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
