using System.Threading.Tasks;

namespace Adapters.Transactions
{
    public interface ITransaction
    {
        void BeginTransaction();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
