using System.Threading;
using System.Threading.Tasks;
using CleanWebApi.Application.Interfaces;
using CleanWebApi.Application.Samples.Models;
using MediatR;

namespace CleanWebApi.Application.Samples.Queries.GetMessage
{
    public class GetMessageQueryHandler : IRequestHandler<GetMessageQuery, SampleViewModel>
    {
        private readonly IDateTimeOffset _dateTimeOffset;

        public GetMessageQueryHandler(IDateTimeOffset dateTimeOffset)
        {
            _dateTimeOffset = dateTimeOffset;
        }

        public Task<SampleViewModel> Handle(GetMessageQuery request, CancellationToken cancellationToken = default)
        {
            var viewModel = new SampleViewModel
            {
                Message = "Sample message",
                Timestamp = _dateTimeOffset.Now
            };

            return Task.FromResult(viewModel);
        }
    }
}