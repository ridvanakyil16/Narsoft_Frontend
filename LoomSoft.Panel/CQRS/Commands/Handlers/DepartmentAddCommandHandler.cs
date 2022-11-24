using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class DepartmentAddCommandHandler : IRequestHandler<DepartmentAddCommandRequest, IReturnData<DepartmentAddCommandResponse>>
    {
        public async Task<IReturnData<DepartmentAddCommandResponse>> Handle(DepartmentAddCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                IReturnData<DepartmentAddCommandResponse> apiData = ApiRequest<DepartmentAddCommandResponse>.SendRequest("User/AddDepartment", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<DepartmentAddCommandResponse>()
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
