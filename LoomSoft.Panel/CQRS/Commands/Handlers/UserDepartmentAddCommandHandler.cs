using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserDepartmentAddCommandHandler : IRequestHandler<UserDepartmentAddCommandRequest, IReturnData<UserDepartmentAddCommandResponse>>
    {
        public async Task<IReturnData<UserDepartmentAddCommandResponse>> Handle(UserDepartmentAddCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                IReturnData<UserDepartmentAddCommandResponse> apiData = ApiRequest<UserDepartmentAddCommandResponse>.SendRequest("User/AddUserDepartment", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserDepartmentAddCommandResponse>()
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
