using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class RoleAuthorityAddCommandHandler : IRequestHandler<RoleAuthorityAddCommandRequest, IReturnData<RoleAuthorityAddCommandResponse>>
    {
        public async Task<IReturnData<RoleAuthorityAddCommandResponse>> Handle(RoleAuthorityAddCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<RoleAuthorityAddCommandResponse> apiData = ApiRequest<RoleAuthorityAddCommandResponse>.SendRequest("User/AddRoleAuthority", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<RoleAuthorityAddCommandResponse>()
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
