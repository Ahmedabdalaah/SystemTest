using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Security.Principal;
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

        public T FindById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void update(T item)
        {
            _context.Update(item);
            _context.SaveChanges(); 
        }
        public SelectList select (int selected = 1)
        {
            List<Category> categ = _context.categories.ToList();
            SelectList catItem = new SelectList(categ, "Id", "Name", selected);
            return catItem;
        }

        public  T GetByPhone(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }
    }
}
