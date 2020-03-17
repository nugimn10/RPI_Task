using System.Threading;
using System.Threading.Tasks;
// using CustomerServices.Application.Interfaces;
using UserServices.Domain.Entities;
using UserServices.Presistences;
using UserServices.Application.UseCase;
using Microsoft.EntityFrameworkCore;
using MediatR;

using System.Net.Http;

namespace UserServices.Application.UseCase.User.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUser, CreateUserDto>
    {
        private readonly usr_context _context;

        public CreateUserHandler (usr_context context)
        {
            _context = context;
        }
        public async Task<CreateUserDto> Handle(CreateUser request, CancellationToken cancellation)
        {

            var users = new Domain.Entities.UsersTB
            {
                name = request.Data.Attributes.name,
                username = request.Data.Attributes.username,
                email = request.Data.Attributes.email,
                password = request.Data.Attributes.password,
                address = request.Data.Attributes.address
            };
            

            _context.Users.Add(users);
            await _context.SaveChangesAsync(cancellation);

            return new CreateUserDto
            {
                Success = true,
                Message = "User successfully created",
            };

        }
    }
}