using LoomSoft.Panel.CQRS.Queries.Requests;
using LoomSoft.Panel.CQRS.Queries.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Queries.Handlers
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQueryRequest, IReturnData<UserGetByIdQueryResponse>>
    {
        public async Task<IReturnData<UserGetByIdQueryResponse>> Handle(UserGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserGetByIdQueryResponse> apiData = ApiRequest<UserGetByIdQueryResponse>.SendRequest("User/UserDetail", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserGetByIdQueryResponse>()
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
