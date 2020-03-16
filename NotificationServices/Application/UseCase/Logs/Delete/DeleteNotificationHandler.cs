using System.Threading;
using System.Threading.Tasks;
using RPI_Task.Presistences;
using RPI_Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace RPI_Task.Application.UseCase.Logs.Delete
{
        public class DeleteLogsHandler : IRequestHandler<DeleteLogs, DeleteLogsDto>
    {
        private readonly notification_context _context;

        public DeleteLogsHandler(notification_context context)
        {
            _context = context;
        }
        public async Task<DeleteLogsDto> Handle(DeleteLogs request, CancellationToken cancellationToken)
        {
            var delete = await _context.Notification.FindAsync(request.Id);

            if (delete == null)
            {
                return new DeleteLogsDto
                {
                    Success = false,
                    Message = "Not Found"
                };
            }

            else
            { 
                _context.Notification.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new DeleteLogsDto
                {
                    Success = true,
                    Message = "Successfully Delete Notification"
                };

            }
           
        }
    }
    
}