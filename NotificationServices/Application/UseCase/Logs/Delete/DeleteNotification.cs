using MediatR;
using System;
using RPI_Task.Domain.Entities;
using RPI_Task.Application.UseCase;

namespace RPI_Task.Application.UseCase.Logs.Delete
{
    public class DeleteLogs : IRequest<DeleteLogsDto>
    {
        public int Id { get; set; }
        public DeleteLogs(int id)
        {
            Id = id;
        }

    }
}