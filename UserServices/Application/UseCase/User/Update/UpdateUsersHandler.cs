using System;
using System.Threading;
using System.Threading.Tasks;
using UserServices.Presistences;
using UserServices.Application.UseCase;
using UserServices.Domain.Entities;
using MediatR;

namespace UserServices.Application.UseCase.User.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, UpdateUserDto>
    {
        private readonly usr_context _context;
        public UpdateUserHandler (usr_context context)
        {
            _context = context;
        }
        public async Task<UpdateUserDto> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var users = _context.Users.Find(request.Data.Attributes.id);

                users.name = request.Data.Attributes.name;
                users.username = request.Data.Attributes.username;
                users.email = request.Data.Attributes.email;
                users.password = request.Data.Attributes.password;
                users.address = request.Data.Attributes.address;


            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateUserDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }
}