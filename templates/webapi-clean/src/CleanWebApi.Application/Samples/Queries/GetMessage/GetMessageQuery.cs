using CleanWebApi.Application.Samples.Models;
using MediatR;
using System;

namespace CleanWebApi.Application.Samples.Queries.GetMessage
{
    public class GetMessageQuery : IRequest<MessageViewModel>
    {
        public Guid Id { get; set; }
    }
}