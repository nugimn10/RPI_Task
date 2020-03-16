using RPI_Task.Domain.Entities;
using RPI_Task.Application.UseCase;

namespace RPI_Task.Application.UseCase.Logs.ReadById
{
    public class ReadLogsByIdDto : BaseDto
    {
        public Notification_logsTB Data { get; set; }
    }
}