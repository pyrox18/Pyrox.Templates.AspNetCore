using CleanWebApi.Application.Samples.Models;
using MediatR;

namespace CleanWebApi.Application.Samples.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<SampleViewModel>
    {
        public string Message { get; set; }
    }
}