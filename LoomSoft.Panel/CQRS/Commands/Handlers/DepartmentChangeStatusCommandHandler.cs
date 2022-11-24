using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class DepartmentChangeStatusCommandHandler : IRequestHandler<DepartmentChangeStatusCommandRequest, IReturnData<DepartmentChangeStatusCommandResponse>>
    {
        public async Task<IReturnData<DepartmentChangeStatusCommandResponse>> Handle(DepartmentChangeStatusCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<DepartmentChangeStatusCommandResponse> apiData = ApiRequest<DepartmentChangeStatusCommandResponse>.SendRequest("User/DepartmentChangeStatus", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<DepartmentChangeStatusCommandResponse>()
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
