using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class BanksConverter
    {
        public static Banks ToDomain(this BanksDb bank)
        {
            return new Banks
            {
                Id = bank.Id,
                BankName = bank.BankName
            };
        }

        public static BanksDb ToStorage(this Banks bank)
        {
            return new BanksDb
            {
                Id = bank.Id,
                BankName = bank.BankName
            };
        }
    }
}
