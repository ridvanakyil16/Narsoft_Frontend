using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserAddCommandHandler : IRequestHandler<UserAddCommandRequest, IReturnData<UserAddCommandResponse>>
    {
        public async Task<IReturnData<UserAddCommandResponse>> Handle(UserAddCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<UserAddCommandResponse> apiData = ApiRequest<UserAddCommandResponse>.SendRequest("User/AddUser", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserAddCommandResponse>()
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
