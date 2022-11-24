using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class RoleChangeStatusCommandHandler : IRequestHandler<RoleChangeStatusCommandRequest, IReturnData<RoleChangeStatusCommandResponse>>
    {
        public async Task<IReturnData<RoleChangeStatusCommandResponse>> Handle(RoleChangeStatusCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<RoleChangeStatusCommandResponse> apiData = ApiRequest<RoleChangeStatusCommandResponse>.SendRequest("User/RoleChangeStatus", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<RoleChangeStatusCommandResponse>()
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
