using RPI_Task.Domain.Entities;
using RPI_Task.Application.UseCase;
using System.Collections.Generic;

namespace RPI_Task.Application.UseCase.Notification.ReadBy
{
    public class ReadNotificationDto : BaseDto
    {
        public IList<NotificationTB> Data { get; set; }
    }
}