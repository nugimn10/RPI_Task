using MediatR;

namespace RPI_Task.Application.UseCase.Notification.ReadById
{

    public class ReadNotificationId: IRequest<ReadNotificationIdDto>
    {
        public int Id { get; set; }
        public ReadNotificationId(int id)
        {
            Id = id;
        }
    }
}