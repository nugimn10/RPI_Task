using MediatR;

namespace UserServices.Application.UseCase.User.ReadById
{

    public class ReadUserByid: IRequest<ReadyUserByIdDto>
    {
        public int Id { get; set; }
        public ReadUserByid(int id)
        {
            Id = id;
        }
    }
}