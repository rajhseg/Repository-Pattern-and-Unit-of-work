using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure
{
    internal class EFTransaction : ITransaction
    {
        public IDbContextTransaction DBTransaction { get; }

        public EFTransaction(IDbContextTransaction inner)
        {
            DBTransaction = inner;
        }

        public async ValueTask DisposeAsync()
        {
            if (DBTransaction == null)
                return;

            await DBTransaction.DisposeAsync();
        }

        public async Task CommitAsync()
        {
            await DBTransaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await DBTransaction.RollbackAsync();
        }

        public void Dispose()
        {
            if (DBTransaction == null)
                return;

            DBTransaction.Dispose();
        }
    }
}
