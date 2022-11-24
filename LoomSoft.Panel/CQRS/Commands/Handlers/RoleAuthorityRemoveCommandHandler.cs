using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class RoleAuthorityRemoveCommandHandler : IRequestHandler<RoleAuthorityRemoveCommandRequest, IReturnData<RoleAuthorityRemoveCommandResponse>>
    {
        public async Task<IReturnData<RoleAuthorityRemoveCommandResponse>> Handle(RoleAuthorityRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<RoleAuthorityRemoveCommandResponse> apiData = ApiRequest<RoleAuthorityRemoveCommandResponse>.SendRequest("User/RemoveRoleAuthority", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<RoleAuthorityRemoveCommandResponse>()
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
