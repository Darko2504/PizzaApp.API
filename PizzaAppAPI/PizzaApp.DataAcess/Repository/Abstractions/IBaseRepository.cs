namespace PizzaApp.DataAcess.Repository.Abstractions
{
    public interface IBaseRepository<T> //where T : class
    {
        Task Add(T entity);
        Task Remove(T entity);  
        Task Update(T entity);
        Task<T> GetById(string id);
        Task<T> GetByIdInt(int id);
        Task<List<T>> GetAll();
        Task SaveChanges();
    }
}
