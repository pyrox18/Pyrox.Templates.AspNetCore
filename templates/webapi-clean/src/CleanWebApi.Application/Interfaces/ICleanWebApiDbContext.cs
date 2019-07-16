using System.Threading;
using System.Threading.Tasks;

namespace CleanWebApi.Application.Interfaces
{
    public interface ICleanWebApiDbContext
    {
        // Add DbSets for domain entities here.

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}