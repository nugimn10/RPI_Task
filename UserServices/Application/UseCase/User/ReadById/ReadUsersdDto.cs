using UserServices.Domain.Entities;
using UserServices.Application.UseCase;

namespace UserServices.Application.UseCase.User.ReadById
{
    public class ReadyUserByIdDto : BaseDto
    {
        public UsersTB Data { get; set; }
    }
}