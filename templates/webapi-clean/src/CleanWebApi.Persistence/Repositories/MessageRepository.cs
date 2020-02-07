using CleanWebApi.Application.Interfaces;
using CleanWebApi.Domain.Entities;

namespace CleanWebApi.Persistence.Repositories
{
    public class MessageRepository : EfRepository<Message>, IMessageRepository
    {
        public MessageRepository(CleanWebApiDbContext context) : base(context)
        {
        }
    }
}
