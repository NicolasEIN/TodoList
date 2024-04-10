namespace TodoList.IRepository
{
    public interface IRepository <T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task<T> Insert(T entity);
        Task<T> Update(T entity, int id);
        Task<T> Delete(int id);
    }
}
