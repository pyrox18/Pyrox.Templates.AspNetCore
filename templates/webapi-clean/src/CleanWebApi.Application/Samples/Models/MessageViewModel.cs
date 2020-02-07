using System;

namespace CleanWebApi.Application.Samples.Models
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}