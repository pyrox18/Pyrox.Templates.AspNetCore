using CleanWebApi.Domain.Entities;

namespace CleanWebApi.Application.Interfaces
{
    public interface IMessageRepository : IAsyncRepository<Message>
    {
        // Add repository methods that are specific to Message here.
    }
}
