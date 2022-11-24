﻿using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class UserDepartmentRemoveCommandHandler : IRequestHandler<UserDepartmentRemoveCommandRequest, IReturnData<UserDepartmentRemoveCommandResponse>>
    {
        public async Task<IReturnData<UserDepartmentRemoveCommandResponse>> Handle(UserDepartmentRemoveCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                IReturnData<UserDepartmentRemoveCommandResponse> apiData = ApiRequest<UserDepartmentRemoveCommandResponse>.SendRequest("User/RemoveUserDepartment", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<UserDepartmentRemoveCommandResponse>()
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
