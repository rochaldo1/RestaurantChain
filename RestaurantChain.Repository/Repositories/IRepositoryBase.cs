namespace RestaurantChain.Repository.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    int Create(TEntity entity);
    void Delete(int id);
    TEntity Get(int id);
    void Update(TEntity entity);
}