using LoomSoft.Panel.CQRS.Commands.Requests;
using LoomSoft.Panel.CQRS.Commands.Responses;
using LoomSoft.Panel.Helpers;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace LoomSoft.Panel.CQRS.Commands.Handlers
{
    public class AuthorityChangeStatusCommandHandler : IRequestHandler<AuthorityChangeStatusCommandRequest, IReturnData<AuthorityChangeStatusCommandResponse>>
    {
        public async Task<IReturnData<AuthorityChangeStatusCommandResponse>> Handle(AuthorityChangeStatusCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<AuthorityChangeStatusCommandResponse> apiData = ApiRequest<AuthorityChangeStatusCommandResponse>.SendRequest("User/AuthorityChangeStatus", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<AuthorityChangeStatusCommandResponse>()
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

    public class LeaveStepConcludeByLeaveIdCommandHandler : IRequestHandler<LeaveStepConcludeByLeaveIdCommandRequest, IReturnData<LeaveStepConcludeByLeaveIdCommandResponse>>
    {
        public async Task<IReturnData<LeaveStepConcludeByLeaveIdCommandResponse>> Handle(LeaveStepConcludeByLeaveIdCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IReturnData<LeaveStepConcludeByLeaveIdCommandResponse> apiData = ApiRequest<LeaveStepConcludeByLeaveIdCommandResponse>.SendRequest("Leave/ConcludeLeave", JsonConvert.SerializeObject(request), "POST");
                return apiData;
            }
            catch (Exception ex)
            {
                return new IReturnData<LeaveStepConcludeByLeaveIdCommandResponse>()
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
