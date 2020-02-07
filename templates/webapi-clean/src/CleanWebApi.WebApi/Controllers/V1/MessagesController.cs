using System;
using System.Threading.Tasks;
using CleanWebApi.Application.Samples.Commands.CreateMessage;
using CleanWebApi.Application.Samples.Models;
using CleanWebApi.Application.Samples.Queries.GetMessage;
using CleanWebApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanWebApi.WebApi.Controllers.V1
{
    public class MessagesController : BaseV1Controller
    {
        /// <summary>
        /// Retrieves a message with the given ID.
        /// </summary>
        /// <response code="200">Returns a message.</response>
        [HttpGet("messages/{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(MessageViewModel), 200)]
        public async Task<ActionResult<MessageViewModel>> GetMessage(Guid id)
        {
            var result = await Mediator.Send(new GetMessageQuery { Id = id });

            return Ok(result);
        }

        /// <summary>
        /// Creates a message.
        /// </summary>
        /// <param name="command">Message details.</param>
        /// <response code="200">Returns the created message.</response>
        /// <response code="400">Indicates a validation error.</response>
        [HttpPost("message")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(MessageViewModel), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        public async Task<ActionResult<MessageViewModel>> CreateMessage(CreateMessageCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}