using MediatR;
using System;
using UserServices.Domain.Entities;
using UserServices.Application.UseCase;

namespace UserServices.Application.UseCase.User.Delete
{
    public class DeleteUser : IRequest<DeleteUserDto>
    {
        public int Id { get; set; }
        public DeleteUser(int id)
        {
            Id = id;
        }

    }
}