using System.Threading;
using System.Threading.Tasks;
using RPI_Task.Presistences;
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

            return new ReadNotificationDto
            {
                Success = true,
                Message = "Message successfully retrieved",
                Data = data
            };

        }
    }
}