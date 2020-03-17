using System.Threading;
using System.Threading.Tasks;
using UserServices.Presistences;
using UserServices.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using MediatR;

namespace UserServices.Application.UseCase.User.ReadById
{
    public class ReadLogsByIdHandler : IRequestHandler<ReadUserByid, ReadyUserByIdDto>
    {
        private readonly user_context _context;

        public ReadLogsByIdHandler(user_context context)
        {
            _context = context;
        }
        public async Task<ReadyUserByIdDto> Handle(ReadUserByid request, CancellationToken cancellationToken)
        {

            var data = await _context.Users.FirstOrDefaultAsync(e => e.id == request.Id);

            return new ReadyUserByIdDto
            {
                Success = true,
                Message = "Message successfully retrieved",
                Data = new Users
                {
                    name = data.name,
                    username = data.username,
                    email = data.email,
                    password = data.password,
                    address = data.address
                }
            };

        }
    }
}