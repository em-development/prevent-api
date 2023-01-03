using Adapters.Services.Files;
using Adapters.Transactions;
using Microsoft.AspNetCore.Mvc.Filters;


namespace API.Filters
{
    public class TransactionFilter : ActionFilterAttribute
    {
        private readonly ITransaction _transaction;
        private readonly IFileStorageService _fileStorageService;

        public TransactionFilter(
            ITransaction transaction,
            IFileStorageService fileStorageService)
        {
            _transaction = transaction;
            _fileStorageService = fileStorageService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _transaction.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null && context.ModelState.IsValid)
            {
                _transaction.CommitTransactionAsync();
                _fileStorageService.RunScheduled();
            }
            else
            {
                _transaction.RollbackTransactionAsync();
            }
        }
    }
}