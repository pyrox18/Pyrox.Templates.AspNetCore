using System.Threading;
using System.Threading.Tasks;
using CleanWebApi.Application.Interfaces;
using CleanWebApi.Application.Samples.Models;
using MediatR;

namespace CleanWebApi.Application.Samples.Commands.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, SampleViewModel>
    {
        private readonly IDateTimeOffset _dateTimeOffset;

        public CreateMessageCommandHandler(IDateTimeOffset dateTimeOffset)
        {
            _dateTimeOffset = dateTimeOffset;
        }

        public Task<SampleViewModel> Handle(CreateMessageCommand request, CancellationToken cancellationToken = default)
        {
            var viewModel = new SampleViewModel
            {
                Message = request.Message,
                Timestamp = _dateTimeOffset.Now
            };

            return Task.FromResult(viewModel);
        }
    }
}