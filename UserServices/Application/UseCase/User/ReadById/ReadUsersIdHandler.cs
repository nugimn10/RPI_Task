using System.Threading;
using System.Threading.Tasks;
using UserServices.Presistences;
using UserServices.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using MediatR;
using MimeKit;
using MailKit.Net.Smtp;
using System;

namespace UserServices.Application.UseCase.User.ReadById
{
    public class ReadLogsByIdHandler : IRequestHandler<ReadUserByid, ReadyUserByIdDto>
    {
        private readonly usr_context _context;

        public ReadLogsByIdHandler(usr_context context)
        {
            _context = context;
        }
        public async Task<ReadyUserByIdDto> Handle(ReadUserByid request, CancellationToken cancellationToken)
        {

            var data = await _context.Users.FirstOrDefaultAsync(e => e.id == request.Id);
            if (data == null)
            { 
                return null; 
            }
            else
            {
        	 	var message = new MimeMessage();
        		message.From.Add(new MailboxAddress("Another background h", "whatisbackgroundh@gmail.com"));
        		message.To.Add(new MailboxAddress("Another background a", "whatisbackgrounda@gmail.com"));
        		message.Subject = "Requesting a data";
        		message.Body = new TextPart("plain")
        		{
          		Text = @"You're requesting and getting a customer data."
        		};
        		using (var client = new SmtpClient())
        		{
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.mailtrap.io", 2525, false);
                    client.Authenticate("b273ce438cbb61", "54439c79c1ca2a"); //buka mailtrap, demo inbox. copy-paste username dan password  
                    client.Send(message);
                    client.Disconnect(true);
                    Console.WriteLine("E-mail Sent");
        		}
                return new ReadyUserByIdDto
                {
                    Success = true,
                    Message = "Message successfully retrieved",
                    Data = new UsersTB
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
}