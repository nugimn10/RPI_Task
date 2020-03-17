using System.Threading;
using System.Threading.Tasks;
using UserServices.Presistences;
using UserServices.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using MediatR;

namespace UserServices.Application.UseCase.User.ReadBy
{
    public class ReadUserHandler : IRequestHandler<ReadUser, ReadUserDto>
    {
        private readonly user_context _context;

        public ReadUserHandler(user_context context)
        {
            _context = context;
        }
        public async Task<ReadUserDto> Handle(ReadUser request, CancellationToken cancellationToken)
        {

            var data = await _context.Users.ToListAsync();

            return new ReadUserDto
            {
                Success = true,
                Message = "Message successfully retrieved",
                Data = data
            };

        }
    }
}