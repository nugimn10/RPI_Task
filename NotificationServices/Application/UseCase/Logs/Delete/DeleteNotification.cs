using MediatR;
using System;
using RPI_Task.Domain.Entities;
using RPI_Task.Application.UseCase;

namespace RPI_Task.Application.UseCase.Notification.Delete
{
    public class DeleteNotification : IRequest<DeleteNotificationDto>
    {
        public int Id { get; set; }
        public DeleteNotification(int id)
        {
            Id = id;
        }

    }
}