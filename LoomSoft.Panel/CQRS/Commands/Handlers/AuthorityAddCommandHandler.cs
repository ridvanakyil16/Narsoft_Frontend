using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class AuthorityAddCommandHandler : IRequestHandler<AuthorityAddCommandRequest, IReturnData<AuthorityAddCommandResponse>>
    {
        public async Task<IReturnData<AuthorityAddCommandResponse>> Handle(AuthorityAddCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<AuthorityAddCommandResponse> apiData = ApiRequest<AuthorityAddCommandResponse>.SendRequest("User/AddAuthority", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<AuthorityAddCommandResponse>()
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
