using FluentValidation;

namespace CleanWebApi.Application.Samples.Commands.CreateMessage
{
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageCommandValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty();
        }
    }
}