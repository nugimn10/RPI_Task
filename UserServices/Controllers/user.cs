using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UserServices.Application.UseCase.User.Create;
using UserServices.Application.UseCase.User.Update;
using UserServices.Application.UseCase.User.ReadBy;
using UserServices.Application.UseCase.User.ReadById;
using UserServices.Application.UseCase.User.Delete;
using UserServices.Presistences;

namespace UserServices.Controllers
{
    [ApiController]
    [Route("user")]
    public class NotifController : ControllerBase
    {
        public IMediator _mediatr;
        public NotifController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpGet]
        public async Task<ActionResult<ReadUserDto>> GetNotif()
        {
            return Ok(await _mediatr.Send(new ReadUser()));
        }
        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> PostNotif( CreateUser yo)
        {
            return Ok(await _mediatr.Send(yo));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadyUserByIdDto>> GetById(int id)
        {
            return Ok(await _mediatr.Send(new ReadUserByid(id)));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotif(int id, UpdateUser data)
        {
            data.Data.Attributes.id = id;
            return Ok(await _mediatr.Send(data));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotif(int id)
        {
            var command = new DeleteUser(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });
        }
    }
}