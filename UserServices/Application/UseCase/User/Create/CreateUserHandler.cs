using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// using CustomerServices.Application.Interfaces;
using UserServices.Domain.Entities;
using UserServices.Presistences;
using UserServices.Application.UseCase;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace UserServices.Application.UseCase.User.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUser, CreateUserDto>
    {
        private readonly usr_context _context;
        private static readonly HttpClient client = new HttpClient();

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
            await _context.SaveChangesAsync();

            var user = _context.Users.First(n => n.username == request.Data.Attributes.username);
            var target = new Target() {Id = user.id, Email_destination = user.email};

            var postnotif = new PostNotif()
            {
                Title = "This is Sample app",
                Message = "Please do not judge me",
                Type = "email",
                From = 1,
                Targets = new List<Target>() {target}
            };

            var attributes = new Data<PostNotif>()
            {Attributes = postnotif };

            var HttpContent = new RequestData<PostNotif>()
            {Data = attributes};

            var jsonObj =JsonConvert.SerializeObject(HttpContent);
      

            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // channel.QueueDeclare( queue : "uvuvueuwe", durable: true, autoDelete: false, arguments: null);
                channel.ExchangeDeclare(exchange : "uvuvueuwe", type : ExchangeType.Fanout);

                // var jsonisation = JsonConvert.SerializeObject(postnotif);

                var jsondata = Encoding.UTF8.GetBytes(jsonObj);
                
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange : "uvuvueuwe", routingKey: "", basicProperties : null, body : jsondata);

                Console.WriteLine($"messages {jsondata} has been sent");
            }
            Console.ReadLine();
 
            // var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");

            // await client.PostAsync("http://localhost:3000/notification", content);
            

            return new CreateUserDto
            {
                Success = true,
                Message = "User successfully created",
            };

        }
    }
}