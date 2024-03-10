using Microsoft.EntityFrameworkCore;
using SystemTest.Data;
using SystemTest.Models;

namespace SystemTest.Services
{
    public class MainRepository<T> : IMainRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public MainRepository(AppDbContext context)
        {
            _context = context;
        }
        public void add(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void delete(T item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void update(T item)
        {
            _context.Update(item);
        }
    }
}
