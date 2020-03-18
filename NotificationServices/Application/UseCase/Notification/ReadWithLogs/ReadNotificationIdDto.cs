using RPI_Task.Domain.Entities;
using RPI_Task.Application.UseCase;
using System.Collections.Generic;

namespace RPI_Task.Application.UseCase.Notification.ReadWithLog
{
    public class ReadNotificationWithLogsDto : BaseDto
    {
        public List<NotificationDTO> Data { get; set; }
    }
}