using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RPI_Task.Presistences;
using System.Linq;
using RPI_Task.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using MediatR;



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
            var result = new List<NotificationData>();

            foreach (var x in data)
            {
                result.Add(new NotificationData {
                    Id = x.id,
                    Title = x.title,
                    Message = x.message
                });
            }
            

            return new ReadNotificationDto
            {
                Message = "Message successfully retrieved",
                Success = true,
               
                Data = result
            };

        }
    }
}
