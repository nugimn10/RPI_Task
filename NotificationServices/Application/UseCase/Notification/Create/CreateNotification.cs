using MediatR;
using System;
using RPI_Task.Domain.Entities;
using RPI_Task.Application.UseCase;
using System.Collections.Generic;

namespace RPI_Task.Application.UseCase.Notification.Create
{
    public class CreateNotification : RequestData<CreateNotifCommand>,IRequest<CreateNotificationDto>
    {
    }
    public class CreateNotifCommand
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public int From { get; set; }
        public List<TargetCommand> Targets { get; set; }
    }

    public class TargetCommand
    {
        public int Id { get; set; }
        public string Email_destination { get; set; }
    }
}
