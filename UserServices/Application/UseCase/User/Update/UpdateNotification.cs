using UserServices.Application.UseCase;
using UserServices.Domain.Entities;
using System;
using MediatR;

namespace UserServices.Application.UseCase.User.Update
{
    public class UpdateUser : RequestData<Users>,IRequest<UpdateUserDto>
    {

    }
}