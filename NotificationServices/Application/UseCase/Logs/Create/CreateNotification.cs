using MediatR;
using System;
using RPI_Task.Domain.Entities;
using RPI_Task.Application.UseCase;
namespace RPI_Task.Application.UseCase.Logs.Create
{
    public class CreateLogs : RequestData<Notification_logsTB>,IRequest<CreateLogsDto>
    {
       
    }
}