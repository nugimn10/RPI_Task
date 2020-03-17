using System.Threading;
using System.Threading.Tasks;
using UserServices.Presistences;
using UserServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace UserServices.Application.UseCase.User.Delete
{
        public class DeleteUserHandler : IRequestHandler<DeleteUser, DeleteUserDto>
    {
        private readonly user_context _context;

        public DeleteUserHandler(user_context context)
        {
            _context = context;
        }
        public async Task<DeleteUserDto> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var delete = await _context.Users.FindAsync(request.Id);

            if (delete == null)
            {
                return new DeleteUserDto
                {
                    Success = false,
                    Message = "Not Found"
                };
            }

            else
            { 
                _context.Users.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new DeleteUserDto
                {
                    Success = true,
                    Message = "Successfully Delete Notification"
                };

            }
           
        }
    }
    
}