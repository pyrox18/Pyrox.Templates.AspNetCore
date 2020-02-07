using System.Threading;
using System.Threading.Tasks;
using CleanWebApi.Application.Interfaces;
using CleanWebApi.Application.Samples.Models;
using MediatR;

namespace CleanWebApi.Application.Samples.Queries.GetMessage
{
    public class GetMessageQueryHandler : IRequestHandler<GetMessageQuery, MessageViewModel>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessageQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<MessageViewModel> Handle(GetMessageQuery request, CancellationToken cancellationToken = default)
        {
            var message = await _messageRepository.GetByIdAsync(request.Id);

            var viewModel = new MessageViewModel
            {
                Id = message.Id,
                Content = message.Content,
                Timestamp = message.Timestamp
            };

            return viewModel;
        }
    }
}