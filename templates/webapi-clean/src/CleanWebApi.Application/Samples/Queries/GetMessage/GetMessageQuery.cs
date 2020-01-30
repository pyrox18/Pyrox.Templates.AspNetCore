using CleanWebApi.Application.Samples.Models;
using MediatR;

namespace CleanWebApi.Application.Samples.Queries.GetMessage
{
    public class GetMessageQuery : IRequest<SampleViewModel>
    {
    }
}