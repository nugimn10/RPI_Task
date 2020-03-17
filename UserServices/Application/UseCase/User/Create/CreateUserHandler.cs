using System.Threading;
using System.Threading.Tasks;
// using CustomerServices.Application.Interfaces;
using UserServices.Domain.Entities;
using UserServices.Presistences;
using UserServices.Application.UseCase;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace UserServices.Application.UseCase.User.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUser, CreateUserDto>
    {
        private readonly user_context _context;

        public CreateUserHandler (user_context context)
        {
            _context = context;
        }
        public async Task<CreateUserDto> Handle(CreateUser request, CancellationToken cancellationToken)
        {

            var notification = new Domain.Entities.Users
            {
                name = request.DataD.Attributes.name,
                username = request.DataD.Attributes.username,
                email = request.DataD.Attributes.email,
                password = request.DataD.Attributes.password,
                address = request.DataD.Attributes.address
            };
            

            _context.Users.Add(notification);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateUserDto
            {
                Success = true,
                Message = "Logs successfully created",
            };

        }
    }
}