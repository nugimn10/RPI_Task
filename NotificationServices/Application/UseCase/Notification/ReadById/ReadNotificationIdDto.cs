using RPI_Task.Domain.Entities;
using RPI_Task.Application.UseCase;

namespace RPI_Task.Application.UseCase.Notification.ReadById
{
    public class ReadNotificationIdDto : BaseDto
    {
        public NotificationTB Data { get; set; }
    }
}