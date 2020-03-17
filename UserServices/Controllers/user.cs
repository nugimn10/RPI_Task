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

namespace UserServices.Presenter.Controllers
{
    [ApiController]
    [Route("notification")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediatr;

        public CustomerController(IMediator Mediator)
        {
            _mediatr = Mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ReadUserDto>> GetCustomer()
        {
            var result = new ReadUser();
            return Ok(await _mediatr.Send(result));
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer( CreateUser payload)
        {
            var result = await _mediatr.Send(payload);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadyUserByIdDto>> GetCustomerById(int id)
        {
            var result = new ReadUserByid(id);
            return Ok(await _mediatr.Send(result));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int ID, UpdateUser data)
        {
            data.DataD.Attributes.id = ID;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUser(id);
            var result = await _mediatr.Send(command);

            return result != null ? (ActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });

        }
    }
}