﻿using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class PasswordChangeCommandHandler : IRequestHandler<PasswordChangeCommandRequest, IReturnData<PasswordChangeCommandResponse>>
    {
        public async Task<IReturnData<PasswordChangeCommandResponse>> Handle(PasswordChangeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<PasswordChangeCommandResponse> apiData = ApiRequest<PasswordChangeCommandResponse>.SendRequest("Auth/PasswordChange", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<PasswordChangeCommandResponse>()
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
