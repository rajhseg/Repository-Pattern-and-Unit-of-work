namespace Domain.Interfaces
{
    public interface ITransaction : IDisposable, IAsyncDisposable
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}
