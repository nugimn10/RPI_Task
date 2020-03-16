using System.Threading;
using System.Threading.Tasks;
using RPI_Task.Presistences;
using RPI_Task.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using MediatR;

namespace RPI_Task.Application.UseCase.Logs.ReadBy
{
    public class ReadLogsHandler : IRequestHandler<ReadLogs, ReadLogsDto>
    {
        private readonly notification_context _context;

        public ReadLogsHandler(notification_context context)
        {
            _context = context;
        }
        public async Task<ReadLogsDto> Handle(ReadLogs request, CancellationToken cancellationToken)
        {

            var data = await _context.Notification_Logs.ToListAsync();

            return new ReadLogsDto
            {
                Success = true,
                Message = "Message successfully retrieved",
                Data = data
            };

        }
    }
}