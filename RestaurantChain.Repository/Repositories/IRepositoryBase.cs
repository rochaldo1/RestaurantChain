namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Базовый интерфейс для репозитрия
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepositoryBase<TEntity> where TEntity : class
{
    /// <summary>
    /// Создать сущность
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    int Create(TEntity entity);
    
    /// <summary>
    /// Удалить сущность
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить сущность
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TEntity Get(int id);
    
    /// <summary>
    /// Обновление сущности
    /// </summary>
    /// <param name="entity"></param>
    void Update(TEntity entity);
}