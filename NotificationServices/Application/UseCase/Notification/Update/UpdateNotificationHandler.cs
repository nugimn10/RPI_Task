using System;
using System.Threading;
using System.Threading.Tasks;
using RPI_Task.Presistences;
using RPI_Task.Application.UseCase;
using RPI_Task.Domain.Entities;
using MediatR;

namespace RPI_Task.Application.UseCase.Notification.Update
{
    public class UpdateNotificationHandler: IRequestHandler<UpdateNotification, UpdateNotificationDto>
    {
        private readonly notification_context _context;
        public UpdateNotificationHandler(notification_context context)
        {
            _context = context;
        }
        public async Task<UpdateNotificationDto> Handle(UpdateNotification request, CancellationToken cancellationToken)
        {
            var notification = _context.Notification.Find(request.Data.Attributes.id);

            notification.title = request.Data.Attributes.title;
            notification.message = request.Data.Attributes.message;
            notification.updated_at = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateNotificationDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }
}