namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitTransactionAsync(ITransaction transaction);

        Task RollbackTransactionAsync(ITransaction transaction);

        Task<ITransaction> BeginTransactionAsync();
    }
}
