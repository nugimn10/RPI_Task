using RPI_Task.Domain.Entities;
using RPI_Task.Application.UseCase;
using System.Collections.Generic;

namespace RPI_Task.Application.UseCase.Logs.ReadBy
{
    public class ReadLogsDto : BaseDto
    {
        public IList<Notification_logsTB> Data { get; set; }
    }
}