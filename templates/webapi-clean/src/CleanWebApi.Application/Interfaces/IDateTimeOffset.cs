using System;

namespace CleanWebApi.Application.Interfaces
{
    public interface IDateTimeOffset
    {
        DateTimeOffset Now { get; }
    }
}