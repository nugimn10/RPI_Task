using System;
using System.Threading;
using System.Threading.Tasks;
using RPI_Task.Presistences;
using RPI_Task.Application.UseCase;
using RPI_Task.Domain.Entities;
using MediatR;

namespace RPI_Task.Application.UseCase.Logs.Update
{
    public class UpdateNotifLogsHandler : IRequestHandler<UpdateLogs, UpdateLogsDto>
    {
        private readonly notification_context _context;
        public UpdateNotifLogsHandler (notification_context context)
        {
            _context = context;
        }
        public async Task<UpdateLogsDto> Handle(UpdateLogs request, CancellationToken cancellationToken)
        {
            var Logs = _context.Notification_Logs.Find(request.DataD.Attributes.id);

                Logs.notification_id = request.DataD.Attributes.notification_id;
                Logs.type = request.DataD.Attributes.type;
                Logs.from = request.DataD.Attributes.from;
                Logs.target = request.DataD.Attributes.target;
                Logs.email_destination = request.DataD.Attributes.email_destination;
                Logs.read_at = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);
                Logs.update_at = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateLogsDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }
}