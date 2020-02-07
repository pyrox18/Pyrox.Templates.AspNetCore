using System.Threading;
using System.Threading.Tasks;
using CleanWebApi.Application.Interfaces;
using CleanWebApi.Application.Samples.Models;
using CleanWebApi.Domain.Entities;
using MediatR;

namespace CleanWebApi.Application.Samples.Commands.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, MessageViewModel>
    {
        private readonly IDateTimeOffset _dateTimeOffset;
        private readonly IMessageRepository _messageRepository;

        public CreateMessageCommandHandler(IDateTimeOffset dateTimeOffset, IMessageRepository messageRepository)
        {
            _dateTimeOffset = dateTimeOffset;
            _messageRepository = messageRepository;
        }

        public async Task<MessageViewModel> Handle(CreateMessageCommand request, CancellationToken cancellationToken = default)
        {
            var message = new Message(request.Message, _dateTimeOffset.Now);

            var messageResult = await _messageRepository.AddAsync(message);

            var viewModel = new MessageViewModel
            {
                Id = messageResult.Id,
                Content = messageResult.Content,
                Timestamp = messageResult.Timestamp
            };

            return viewModel;
        }
    }
}