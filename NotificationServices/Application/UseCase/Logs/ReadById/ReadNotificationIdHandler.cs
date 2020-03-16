using System.Threading;
using System.Threading.Tasks;
using RPI_Task.Presistences;
using RPI_Task.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using MediatR;

namespace RPI_Task.Application.UseCase.Logs.ReadById
{
    public class ReadLogsByIdHandler : IRequestHandler<ReadLogsById, ReadLogsByIdDto>
    {
        private readonly notification_context _context;

        public ReadLogsByIdHandler(notification_context context)
        {
            _context = context;
        }
        public async Task<ReadLogsByIdDto> Handle(ReadLogsById request, CancellationToken cancellationToken)
        {

            var data = await _context.Notification_Logs.FirstOrDefaultAsync(e => e.id == request.Id);

            return new ReadLogsByIdDto
            {
                Success = true,
                Message = "Message successfully retrieved",
                Data = new Notification_logsTB
                {
                    notification_id = data.notification_id,
                    type = data.type,
                    from = data.from,
                    target = data.target,
                    email_destination = data.email_destination
                }
            };

        }
    }
}