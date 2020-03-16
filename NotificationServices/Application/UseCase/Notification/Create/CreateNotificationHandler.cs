using System.Threading;
using System.Threading.Tasks;
// using CustomerServices.Application.Interfaces;
using RPI_Task.Domain.Entities;
using RPI_Task.Presistences;
using RPI_Task.Application.UseCase;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace RPI_Task.Application.UseCase.Notification.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateNotification, CreateNotificationDto>
    {
        private readonly notification_context _context;

        public CreateCustomerCommandHandler (notification_context context)
        {
            _context = context;
        }
        public async Task<CreateNotificationDto> Handle(CreateNotification request, CancellationToken cancellationToken)
        {

            var customer = new Domain.Entities.NotificationTB
            {
                title = request.DataD.Attributes.title,
                message = request.DataD.Attributes.message,
                created_at = request.DataD.Attributes.created_at,
                updated_at = request.DataD.Attributes.updated_at
            };
            

            _context.Notification.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateNotificationDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}