using Dapper;

using Npgsql;

using RestaurantChain.Domain.Models.Reports;
using RestaurantChain.Infrastructure.Converters;
using RestaurantChain.Infrastructure.Entities.Reports;
using RestaurantChain.Repository.Repositories;

namespace RestaurantChain.Infrastructure.Repositories;

internal sealed class ReportsRepository : RepositoryBase, IReportsRepository
{
    public ReportsRepository(NpgsqlConnection connection) : base(connection)
    {
    }

    public IReadOnlyCollection<DishesSumByPeriod> GetDishesSumByPeriod(DateTime startDate, DateTime endDate)
    {
        const string query = @"
select
   r.restaurant_name as RestaurantName,
   date_trunc('day', s.sale_date) as Date,
   god.group_name as GroupName,
   d.dish_name as DishName,
   SUM(s.price * s.quantity) as Price,
   COUNT(*) as SaleCount
from sales s
   inner join public.dishes d on d.id = s.dish_id
   inner join public.groups_of_dishes god on god.id = d.group_id
   inner join restaurants r on r.id = s.restaurant_id
where
    s.sale_date >= @From AND
    s.sale_date <= @To
group by
   r.restaurant_name,
   date_trunc('day', s.sale_date),
   god.group_name,
   d.dish_name
order by
   r.restaurant_name, 
   date_trunc('day', s.sale_date),
   god.group_name,
   d.dish_name";
        IEnumerable<DishesSumByPeriodDb> entities = Connection.Query<DishesSumByPeriodDb>(
            query,
            new
            {
                From = startDate.Date,
                To = endDate.Date
            });

        return entities.Select(x => x.ToDomain()).ToArray();
    }

    public IReadOnlyCollection<RestaurantSumByPeriod> GetRestaurantSumByPeriods(DateTime startDate, DateTime endDate)
    {
        const string query = @"
select
   r.restaurant_name as RestaurantName,
   date_trunc('day', s.sale_date) as Date,
   SUM(s.price*s.quantity) as Price,
   COUNT(*) as SaleCount
from sales s
   inner join restaurants r on r.id = s.restaurant_id
   inner join public.dishes d on d.id = s.dish_id
where
    s.sale_date >= @From AND
    s.sale_date <= @To
group by
   r.restaurant_name,
   date_trunc('day', s.sale_date)";
        IEnumerable<RestaurantSumByPeriodDb> entities = Connection.Query<RestaurantSumByPeriodDb>(
            query,
            new
            {
                From = startDate,
                To = endDate
            });

        return entities.Select(x => x.ToDomain()).ToArray();
    }
}