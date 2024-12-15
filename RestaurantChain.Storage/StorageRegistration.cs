using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Storage
{
    public static class StorageRegistration
    {
        public static void UseStorage(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>(_ => new UnitOfWork(connectionString));
        }
    }
}
