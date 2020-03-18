using RPI_Task.Application.UseCase;
using RPI_Task.Domain.Entities;
using System;
using MediatR;
using System.Collections.Generic;

namespace RPI_Task.Application.UseCase.Notification.Update
{
    public class UpdateNotification : RequestData<putData>,IRequest<UpdateNotificationDto>
    {

    }

    public class putData
    {
        public int Notification_id {get; set;}
        public DateTime Read_at {get; set;}
        public List<Target> Target {get; set;}

    }
    public class Target
    {
        public int Id {get; set;}
    }
}