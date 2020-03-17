using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RPI_Task.Presistences;
using RPI_Task.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using MediatR;

using Hangfire;
using System;
using MimeKit;
using MailKit.Net.Smtp;


namespace RPI_Task.Application.UseCase.Notification.ReadBy
{
    public class ReadNotificationHandler : IRequestHandler<ReadNotification, ReadNotificationDto>
    {
        private readonly notification_context _context;

        public ReadNotificationHandler(notification_context context)
        {
            _context = context;
        }
        public async Task<ReadNotificationDto> Handle(ReadNotification request, CancellationToken cancellationToken)
        {
            

            var data = await _context.Notification.ToListAsync();
            var result = new List<NotificationTB>();

            foreach (var x in data)
            {
                result.Add(new NotificationTB {
                    id = x.id,
                    title = x.title,
                    message = x.message
                });
            }
            

            return new ReadNotificationDto
            {
                Success = true,
                Message = "Message successfully retrieved",
                Data = result
            };

        }
    }
}
