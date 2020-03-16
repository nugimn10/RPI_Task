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
            var notification = _context.Notification.Find(request.DataD.Attributes.id);

            notification.title = request.DataD.Attributes.title;
            notification.message = request.DataD.Attributes.message;
            notification.updated_at = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateNotificationDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }
}