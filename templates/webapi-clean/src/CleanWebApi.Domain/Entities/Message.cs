using System;

namespace CleanWebApi.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string Content { get; private set; }
        public DateTimeOffset Timestamp { get; private set; }

        public Message(string content, DateTimeOffset timestamp)
        {
            Content = content;
            Timestamp = timestamp;
        }
    }
}
