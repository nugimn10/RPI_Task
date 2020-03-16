using RPI_Task.Application.UseCase;
using RPI_Task.Domain.Entities;
using System;
using MediatR;

namespace RPI_Task.Application.UseCase.Notification.Update
{
    public class UpdateNotification : RequestData<NotificationTB>,IRequest<UpdateNotificationDto>
    {

    }
}