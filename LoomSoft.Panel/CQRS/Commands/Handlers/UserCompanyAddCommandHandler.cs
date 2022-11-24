using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserCompanyAddCommandHandler : IRequestHandler<UserCompanyAddCommandRequest, IReturnData<UserCompanyAddCommandResponse>>
    {
        public async Task<IReturnData<UserCompanyAddCommandResponse>> Handle(UserCompanyAddCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserCompanyAddCommandResponse> apiData = ApiRequest<UserCompanyAddCommandResponse>.SendRequest("User/AddUserCompany", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserCompanyAddCommandResponse>()
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
