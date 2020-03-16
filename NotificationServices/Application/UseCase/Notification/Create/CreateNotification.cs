using MediatR;
using System;
using RPI_Task.Domain.Entities;
using RPI_Task.Application.UseCase;
namespace RPI_Task.Application.UseCase.Notification.Create
{
    public class CreateNotification : RequestData<NotificationTB>,IRequest<CreateNotificationDto>
    {
       
    }
}