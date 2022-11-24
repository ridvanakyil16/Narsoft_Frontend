using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class CompanyChangeStatusCommandHandler : IRequestHandler<CompanyChangeStatusCommandRequest, IReturnData<CompanyChangeStatusCommandResponse>>
    {
        public async Task<IReturnData<CompanyChangeStatusCommandResponse>> Handle(CompanyChangeStatusCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<CompanyChangeStatusCommandResponse> apiData = ApiRequest<CompanyChangeStatusCommandResponse>.SendRequest("User/CompanyChangeStatus", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<CompanyChangeStatusCommandResponse>()
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
