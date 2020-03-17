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
        private readonly user_context _context;
        public UpdateUserHandler (user_context context)
        {
            _context = context;
        }
        public async Task<UpdateUserDto> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var users = _context.Users.Find(request.DataD.Attributes.id);

                users.name = request.DataD.Attributes.name;
                users.username = request.DataD.Attributes.username;
                users.email = request.DataD.Attributes.email;
                users.password = request.DataD.Attributes.password;
                users.address = request.DataD.Attributes.address;


            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateUserDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }
}