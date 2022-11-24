using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserCompanyRemoveCommandHandler : IRequestHandler<UserCompanyRemoveCommandRequest, IReturnData<UserCompanyRemoveCommandResponse>>
    {
        public async Task<IReturnData<UserCompanyRemoveCommandResponse>> Handle(UserCompanyRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserCompanyRemoveCommandResponse> apiData = ApiRequest<UserCompanyRemoveCommandResponse>.SendRequest("User/RemoveUserCompany", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserCompanyRemoveCommandResponse>()
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
