using RPI_Task.Application.UseCase;
using RPI_Task.Domain.Entities;
using System;
using MediatR;

namespace RPI_Task.Application.UseCase.Logs.Update
{
    public class UpdateLogs : RequestData<Notification_logsTB>,IRequest<UpdateLogsDto>
    {

    }
}