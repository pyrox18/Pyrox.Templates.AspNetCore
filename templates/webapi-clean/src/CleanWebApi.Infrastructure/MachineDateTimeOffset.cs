using System;
using CleanWebApi.Application.Interfaces;

namespace CleanWebApi.Infrastructure
{
    public class MachineDateTimeOffset : IDateTimeOffset
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}