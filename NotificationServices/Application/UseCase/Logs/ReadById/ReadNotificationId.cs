using MediatR;

namespace RPI_Task.Application.UseCase.Logs.ReadById
{

    public class ReadLogsById: IRequest<ReadLogsByIdDto>
    {
        public int Id { get; set; }
        public ReadLogsById(int id)
        {
            Id = id;
        }
    }
}