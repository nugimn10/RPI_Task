using System.Threading;
using System.Threading.Tasks;
using RPI_Task.Presistences;
using RPI_Task.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using MediatR;

namespace RPI_Task.Application.UseCase.Notification.ReadById
{
    public class ReadNotificationIdhandler : IRequestHandler<ReadNotificationId, ReadNotificationIdDto>
    {
        private readonly notification_context _context;

        public ReadNotificationIdhandler(notification_context context)
        {
            _context = context;
        }
        public async Task<ReadNotificationIdDto> Handle(ReadNotificationId request, CancellationToken cancellationToken)
        {

            var result = await _context.Notification.FirstOrDefaultAsync(e => e.id == request.Id);

            return new ReadNotificationIdDto
            {
                Success = true,
                Message = "Message successfully retrieved",
                Data = new NotificationTB
                {
                    title = result.title,
                    message = result.message,
                }
            };

        }
    }
}