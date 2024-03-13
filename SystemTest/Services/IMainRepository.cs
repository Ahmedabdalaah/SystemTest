using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace SystemTest.Services
{
    public interface IMainRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        void add(T item);
        void update(T item);
        void delete(T item);
        T FindById(int? id);
        SelectList select(int selected = 1);
        T GetByPhone(Expression<Func<T, bool>> predicate);
    }
}
