using System.Threading;
using System.Threading.Tasks;
// using CustomerServices.Application.Interfaces;
using RPI_Task.Domain.Entities;
using RPI_Task.Presistences;
using RPI_Task.Application.UseCase;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace RPI_Task.Application.UseCase.Logs.Create
{
    public class CreatelogsHandler : IRequestHandler<CreateLogs, CreateLogsDto>
    {
        private readonly notification_context _context;

        public CreatelogsHandler (notification_context context)
        {
            _context = context;
        }
        public async Task<CreateLogsDto> Handle(CreateLogs request, CancellationToken cancellationToken)
        {

            var notification = new Domain.Entities.Notification_logsTB
            {
                notification_id = request.DataD.Attributes.notification_id,
                type = request.DataD.Attributes.type,
                from = request.DataD.Attributes.from,
                target = request.DataD.Attributes.target,
                email_destination = request.DataD.Attributes.email_destination,
                read_at =request.DataD.Attributes.read_at,
                create_at = request.DataD.Attributes.create_at,
                update_at = request.DataD.Attributes.update_at

            };
            

            _context.Notification_Logs.Add(notification);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateLogsDto
            {
                Success = true,
                Message = "Logs successfully created",
            };

        }
    }
}