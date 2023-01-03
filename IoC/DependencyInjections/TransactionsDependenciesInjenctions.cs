using Adapters.Transactions;
using Microsoft.Extensions.DependencyInjection;
using Repository.Transaction;

namespace IoC.DependencyInjections
{
    internal static class TransactionsDependenciesInjections
    {
        public static IServiceCollection AddTransaction(this IServiceCollection services)
        {
            services.AddScoped<ITransaction, Transaction>();

            return services;
        }
    }
}
