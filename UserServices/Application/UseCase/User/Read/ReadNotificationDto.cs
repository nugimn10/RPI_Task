using UserServices.Domain.Entities;
using UserServices.Application.UseCase;
using System.Collections.Generic;

namespace UserServices.Application.UseCase.User.ReadBy
{
    public class ReadUserDto : BaseDto
    {
        public IList<Users> Data { get; set; }
    }
}