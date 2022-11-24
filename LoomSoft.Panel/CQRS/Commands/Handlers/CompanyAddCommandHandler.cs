using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class CompanyAddCommandHandler : IRequestHandler<CompanyAddCommandRequest, IReturnData<CompanyAddCommandResponse>>
    {
        public async Task<IReturnData<CompanyAddCommandResponse>> Handle(CompanyAddCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<CompanyAddCommandResponse> apiData = ApiRequest<CompanyAddCommandResponse>.SendRequest("User/AddCompany", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<CompanyAddCommandResponse>()
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
