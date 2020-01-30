using System.Threading.Tasks;
using CleanWebApi.Application.Samples.Commands.CreateMessage;
using CleanWebApi.Application.Samples.Models;
using CleanWebApi.Application.Samples.Queries.GetMessage;
using CleanWebApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanWebApi.WebApi.Controllers.V1
{
    public class SamplesController : BaseV1Controller
    {
        /// <summary>
        /// Retrieves a message.
        /// </summary>
        /// <response code="200">Returns a message.</response>
        [HttpGet("message")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SampleViewModel), 200)]
        public async Task<ActionResult<SampleViewModel>> GetMessage()
        {
            var result = await Mediator.Send(new GetMessageQuery());

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
        [ProducesResponseType(typeof(SampleViewModel), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        public async Task<ActionResult<SampleViewModel>> CreateMessage(CreateMessageCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}