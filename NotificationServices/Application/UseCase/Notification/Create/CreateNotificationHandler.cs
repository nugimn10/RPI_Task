using System.Security.Cryptography.X509Certificates;
using System;
using System.Threading;
using System.Threading.Tasks;
// using CustomerServices.Application.Interfaces;
using RPI_Task.Domain.Entities;
using RPI_Task.Presistences;
using MediatR;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Linq;
using MimeKit;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RPI_Task.Application.UseCase.Notification.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateNotification, CreateNotificationDto>
    {
        private readonly notification_context _context;

        public CreateCustomerCommandHandler (notification_context context)
        {
            _context = context;
        }
        public async Task<CreateNotificationDto> Handle(CreateNotification request, CancellationToken cancellationToken)
        {
            var notificationList = _context.Notification.ToList();

            var notdata = new NotificationTB()
            {
                title = request.Data.Attributes.Title,
                message = request.Data.Attributes.Message
            };

            if (!notificationList.Any(x=>x.title == request.Data.Attributes.Title))
            {
                _context.Notification.Add(notdata);
            }
  
            await _context.SaveChangesAsync();

            var notifselect = _context.Notification.First(x => x.title == request.Data.Attributes.Title);
            foreach (var x in request.Data.Attributes.Targets)
            {
                _context.Notification_Logs.Add(new Notification_logsTB{
                    notification_id = notifselect.id,
                    type = request.Data.Attributes.Type,
                    from = request.Data.Attributes.From,
                    target= x.Id,
                    email_destination = x.Email_destination
                });

                await _context.SaveChangesAsync();

            }

            await _context.SaveChangesAsync();
            return new CreateNotificationDto
            {
                Success = true,
                Message = " successfully created",
            };

        }
        
        public async Task<List<Users>> GetUserData()
        {
            var client = new HttpClient();
            var data = await client.GetStringAsync("http://usersservice/users");
            return JsonConvert.DeserializeObject<List<Users>>(data);

        }
        public async Task SendMail(string emailfrom, string emailto, string subject, string body)
        {
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("b273ce438cbb61", "54439c79c1ca2a"),
                EnableSsl = true
            };
            await client.SendMailAsync(emailfrom, emailto, subject, body);
            Console.WriteLine("Email has been sent");
        }
    }
   
}