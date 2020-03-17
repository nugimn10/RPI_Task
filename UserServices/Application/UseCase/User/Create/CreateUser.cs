using MediatR;
using System;
using UserServices.Domain.Entities;
using UserServices.Application.UseCase;
namespace UserServices.Application.UseCase.User.Create
{
    public class CreateUser : RequestData<Users>,IRequest<CreateUserDto>
    {
       
    }
}