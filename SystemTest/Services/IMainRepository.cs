namespace SystemTest.Services
{
    public interface IMainRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        void add(T item);
        void update(T item);
        void delete(T item);
    }
}
