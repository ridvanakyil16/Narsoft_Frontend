using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class RoleAddCommandHandler : IRequestHandler<RoleAddCommandRequest, IReturnData<RoleAddCommandResponse>>
    {
        public async Task<IReturnData<RoleAddCommandResponse>> Handle(RoleAddCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<RoleAddCommandResponse> apiData = ApiRequest<RoleAddCommandResponse>.SendRequest("User/AddRole", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<RoleAddCommandResponse>()
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
